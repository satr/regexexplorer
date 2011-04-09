namespace LicenseHelper {
    public delegate void OpenLicenseKeyFileHandle(string fileName, LicenseKeyFileEventArgs args);

    public delegate void GotKeyHandle(string key);
}