// This file is automatically generated!

using System;
using System.Runtime.InteropServices;

namespace Steamworks {
	public static class SteamApps {
		public static bool BIsSubscribed() {
			return NativeMethods.ISteamApps_BIsSubscribed();
		}

		public static bool BIsLowViolence() {
			return NativeMethods.ISteamApps_BIsLowViolence();
		}

		public static bool BIsCybercafe() {
			return NativeMethods.ISteamApps_BIsCybercafe();
		}

		public static bool BIsVACBanned() {
			return NativeMethods.ISteamApps_BIsVACBanned();
		}

		public static string GetCurrentGameLanguage() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetCurrentGameLanguage());
		}

		public static string GetAvailableGameLanguages() {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetAvailableGameLanguages());
		}

		// only use this member if you need to check ownership of another game related to yours, a demo for example
		public static bool BIsSubscribedApp(AppId_t appID) {
			return NativeMethods.ISteamApps_BIsSubscribedApp(appID);
		}

		// Takes AppID of DLC and checks if the user owns the DLC & if the DLC is installed
		public static bool BIsDlcInstalled(AppId_t appID) {
			return NativeMethods.ISteamApps_BIsDlcInstalled(appID);
		}

		// returns the Unix time of the purchase of the app
		public static uint GetEarliestPurchaseUnixTime(AppId_t nAppID) {
			return NativeMethods.ISteamApps_GetEarliestPurchaseUnixTime(nAppID);
		}

		// Checks if the user is subscribed to the current app through a free weekend
		// This function will return false for users who have a retail or other type of license
		// Before using, please ask your Valve technical contact how to package and secure your free weekened
		public static bool BIsSubscribedFromFreeWeekend() {
			return NativeMethods.ISteamApps_BIsSubscribedFromFreeWeekend();
		}

		// Returns the number of DLC pieces for the running app
		public static int GetDLCCount() {
			return NativeMethods.ISteamApps_GetDLCCount();
		}

		// Returns metadata for DLC by index, of range [0, GetDLCCount()]
		public static bool BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize) {
			IntPtr pchName2 = Marshal.AllocHGlobal(cchNameBufferSize);
			bool ret = NativeMethods.ISteamApps_BGetDLCDataByIndex(iDLC, out pAppID, out pbAvailable, pchName2, cchNameBufferSize);
			pchName = ret ? InteropHelp.PtrToStringUTF8(pchName2) : null;
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		// Install/Uninstall control for optional DLC
		public static void InstallDLC(AppId_t nAppID) {
			NativeMethods.ISteamApps_InstallDLC(nAppID);
		}

		public static void UninstallDLC(AppId_t nAppID) {
			NativeMethods.ISteamApps_UninstallDLC(nAppID);
		}

		// Request cd-key for yourself or owned DLC. If you are interested in this
		// data then make sure you provide us with a list of valid keys to be distributed
		// to users when they purchase the game, before the game ships.
		// You'll receive an AppProofOfPurchaseKeyResponse_t callback when
		// the key is available (which may be immediately).
		public static void RequestAppProofOfPurchaseKey(AppId_t nAppID) {
			NativeMethods.ISteamApps_RequestAppProofOfPurchaseKey(nAppID);
		}

		// returns current beta branch name, 'public' is the default branch
		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize) {
			IntPtr pchName2 = Marshal.AllocHGlobal(cchNameBufferSize);
			bool ret = NativeMethods.ISteamApps_GetCurrentBetaName(pchName2, cchNameBufferSize);
			pchName = ret ? InteropHelp.PtrToStringUTF8(pchName2) : null;
			Marshal.FreeHGlobal(pchName2);
			return ret;
		}

		// signal Steam that game files seems corrupt or missing
		public static bool MarkContentCorrupt(bool bMissingFilesOnly) {
			return NativeMethods.ISteamApps_MarkContentCorrupt(bMissingFilesOnly);
		}

		// return installed depots in mount order
		public static uint GetInstalledDepots(AppId_t appID, DepotId_t[] pvecDepots, uint cMaxDepots) {
			return NativeMethods.ISteamApps_GetInstalledDepots(appID, pvecDepots, cMaxDepots);
		}

		// returns current app install folder for AppID, returns folder name length
		public static uint GetAppInstallDir(AppId_t appID, out string pchFolder, uint cchFolderBufferSize) {
			IntPtr pchFolder2 = Marshal.AllocHGlobal((int)cchFolderBufferSize);
			uint ret = NativeMethods.ISteamApps_GetAppInstallDir(appID, pchFolder2, cchFolderBufferSize);
			pchFolder = ret != 0 ? InteropHelp.PtrToStringUTF8(pchFolder2) : null;
			Marshal.FreeHGlobal(pchFolder2);
			return ret;
		}

		// returns true if that app is installed (not necessarily owned)
		public static bool BIsAppInstalled(AppId_t appID) {
			return NativeMethods.ISteamApps_BIsAppInstalled(appID);
		}

		// returns the SteamID of the original owner. If different from current user, it's borrowed
		public static CSteamID GetAppOwner() {
			return NativeMethods.ISteamApps_GetAppOwner();
		}

		// Returns the associated launch param if the game is run via steam://run/<appid>//?param1=value1;param2=value2;param3=value3 etc.
		// Parameter names starting with the character '@' are reserved for internal use and will always return and empty string.
		// Parameter names starting with an underscore '_' are reserved for steam features -- they can be queried by the game,
		// but it is advised that you not param names beginning with an underscore for your own features.
		public static string GetLaunchQueryParam(string pchKey) {
			return InteropHelp.PtrToStringUTF8(NativeMethods.ISteamApps_GetLaunchQueryParam(new InteropHelp.UTF8String(pchKey)));
		}
#if _PS3
		// Result returned in a RegisterActivationCodeResponse_t callresult
		public static SteamAPICall_t RegisterActivationCode(string pchActivationCode) {
			return NativeMethods.ISteamApps_RegisterActivationCode(new InteropHelp.UTF8String(pchActivationCode));
		}
#endif
	}
}