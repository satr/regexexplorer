using System.Drawing;
using LicenseHelper;

namespace RegexExplorer {
    public abstract class BaseController : LicenseController {
        public BaseController(Bitmap image) {
            _salt = /*<KeyGeneratorSalt>*/ "83950683" /*</KeyGeneratorSalt>*/;
            CreateTextFileEx(image);
        }
    }
}