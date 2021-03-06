﻿using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Xsolla.Core
{
	[AddComponentMenu("Scripts/Xsolla.Core/Browser/BrowserHelper")]
	public class BrowserHelper : MonoSingleton<BrowserHelper>
	{
		[SerializeField]
		private GameObject inAppBrowserPrefab;
		private GameObject _inAppBrowserObject;

		[DllImport("__Internal")]
		private static extern void Purchase(string token, bool sandbox);

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if(_inAppBrowserObject != null) {
				Destroy(_inAppBrowserObject);
				_inAppBrowserObject = null;
			}
		}

		public void OpenPurchase(string url, string token, bool isSandbox, bool inAppBrowserEnabled = false)
		{
			if((Application.platform == RuntimePlatform.WebGLPlayer) && inAppBrowserEnabled)
			{
				Screen.fullScreen = false;
				Purchase(token, isSandbox);
			} else {
				Open(url + token, inAppBrowserEnabled);
			}
		}

		public void Open(string url, bool inAppBrowserEnabled = false)
		{
			switch (Application.platform) {
				case RuntimePlatform.WebGLPlayer: {
						url = $"window.open(\"{url}\",\"_blank\")";
						Application.ExternalEval(url);
						break;
					}
				default: {
#if (UNITY_EDITOR || UNITY_STANDALONE)
						if (inAppBrowserEnabled && (inAppBrowserPrefab != null)) {
							OpenInAppBrowser(url);
						} else
#endif
							Application.OpenURL(url);
						break;
					}
			}
		}

#if (UNITY_EDITOR || UNITY_STANDALONE)
		private void OpenInAppBrowser(string url)
		{
			if (_inAppBrowserObject == null) {
				Canvas canvas = FindObjectOfType<Canvas>();
				if(canvas == null) {
					Debug.LogError("Can not find canvas! So can not draw 2D browser!");
					return;
				}
				_inAppBrowserObject = Instantiate(inAppBrowserPrefab, canvas.transform);
				XsollaBrowser xsollaBrowser = _inAppBrowserObject.GetComponent<XsollaBrowser>();
				xsollaBrowser.Navigate.To(url);
			} else {
				Debug.LogError("You try create browser instance, but it already created!");
			}
		}

		public SinglePageBrowser2D GetLastBrowser()
		{
			return _inAppBrowserObject == null ? null : _inAppBrowserObject.GetComponent<SinglePageBrowser2D>();
		}
#endif
	}
}
