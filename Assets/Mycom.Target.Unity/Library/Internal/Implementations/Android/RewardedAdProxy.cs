#if UNITY_ANDROID
namespace Mycom.Target.Unity.Internal.Implementations.Android
{
    using System;
    using System.Threading;
    using Interfaces;
    using UnityEngine;

    internal sealed class RewardedAdProxy : AndroidJavaProxy, IRewardedAdProxy
    {
        private readonly AndroidJavaObject _rewardedAdObject;
        
        private Int64 _isDisposed;

        public RewardedAdProxy(UInt32 slotId) : base("com.my.target.ads.RewardedAd$RewardedAdListener")
        {
            var currentActivity = PlatformHelper.CurrentActivity;

            _rewardedAdObject = new AndroidJavaObject("com.my.target.ads.RewardedAd", (Int32)slotId, currentActivity);

            _rewardedAdObject.Call("setListener", this);

            CustomParamsProxy = new CustomParamsProxy(_rewardedAdObject.Call<AndroidJavaObject>("getCustomParams"));
        }

        ~RewardedAdProxy()
        {
            ((IDisposable)this).Dispose();
        }

        public event Action AdClicked;
        public event Action AdLoadCompleted;
        public event Action<String> AdLoadFailed;
        public event Action AdDismissed;
        public event Action AdDisplayed;
        public event Action<String> AdRewarded;

        void IAdProxy.Load()
        {
            if (Interlocked.Read(ref _isDisposed) == 1)
            {
                return;
            }
            _rewardedAdObject.Call("load");
        }

        public ICustomParamsProxy CustomParamsProxy { get; private set; }

        void IDisposable.Dispose()
        {
            if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) != 0)
            {
                return;
            }

            if (_rewardedAdObject != null)
            {
                _rewardedAdObject.Call("destroy");

                _rewardedAdObject.Dispose();
            }

            CustomParamsProxy?.Dispose();

            GC.SuppressFinalize(this);
        }

        void IRewardedAdProxy.Dismiss()
        {
            if (Interlocked.Read(ref _isDisposed) == 1)
            {
                return;
            }

            PlatformHelper.RunInUiThread(() => _rewardedAdObject.Call("dismiss"));
        }

        void IRewardedAdProxy.Show()
        {
            if (Interlocked.Read(ref _isDisposed) == 1)
            {
                return;
            }

            PlatformHelper.RunInUiThread(() => _rewardedAdObject.Call("show"));
        }

        public void onLoad(AndroidJavaObject o) => AdLoadCompleted?.Invoke();
        public void onNoAd(String error, AndroidJavaObject o) => AdLoadFailed?.Invoke(error);
        public void onClick(AndroidJavaObject o) => AdClicked?.Invoke();
        public void onDismiss(AndroidJavaObject o) => AdDismissed?.Invoke();
        public void onReward(AndroidJavaObject reward, AndroidJavaObject source) => AdRewarded?.Invoke(reward.Get<String>("type"));
        public void onDisplay(AndroidJavaObject o) => AdDisplayed?.Invoke();
    }
}
#endif