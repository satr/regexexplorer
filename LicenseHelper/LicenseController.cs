//  To derive License controller and provide a code as shown below. 
//
//  public class DerivedBaseController : LicenseController {
//    public DerivedBaseController() {
//      _hashList = /*<KeyGeneratorHashList>*/ new string[0] /*</KeyGeneratorHashList>*/;
//      _salt = /*<KeyGeneratorSalt>*/ "12345678" /*</KeyGeneratorSalt>*/;
//    }
//  }
//
//  By default keywords "KeyGeneratorHashList" and "KeyGeneratorSalt" are predefined to be 
//  replaced by KeyProviderGUI template pattern generator:
//  "KeyGeneratorHashList" will contain initialization code for hash list of license keys
//  "KeyGeneratorSalt" will contain initialization code for actual salt for this hash list
//
//  By default keywords "KeyKeyGeneratorCheck1" ("KeyKeyGeneratorCheck2",..., "KeyKeyGeneratorCheckN", etc.)
//  are predefined to be replaced by KeyProviderGUI template pattern generator:
//  "KeyKeyGeneratorCheck1" will contain code to check if product is registered,
//  "KeyKeyGeneratorCheck2" will contain some different code to check if product is registered, etc.
//  Sample code:
//  if(/*<KeyKeyGeneratorCheck1>*/LicenseController.IsRegistered/*</KeyKeyGeneratorCheck1>*/)
//    DoRegisteredAction();
//  else
//    DoUnregisteredAction();

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using KeyProvider;

namespace LicenseHelper {
    public abstract class LicenseController {
        protected static string[] _hashList = new string[0];
        protected static string _salt = "12345678";
        public event GotKeyHandle OnGotKey;
        private event GotKeyHandle OnCheckKey;
        protected static bool _isRegistered = false;
        protected static string _key = string.Empty;

        public LicenseController() {
            OnCheckKey += new GotKeyHandle(BaseController_OnCheckKey);
        }

        public void Register(string key) {
            _key = key;
            if (OnCheckKey != null)
                OnCheckKey(key);
        }

        public void RegisterOverForm() {
            LicenseHelperForm licenseHelperForm = new LicenseHelperForm(true);
            if (!licenseHelperForm.AcceptKey())
                return;
            Register(licenseHelperForm.Key);
            if (OnGotKey != null)
                OnGotKey(_key);
        }

        public static bool IsRegistered {
            get { return _isRegistered; }
        }

        private void BaseController_OnCheckKey(string key) {
            _isRegistered = true;//always as it's free now
//            _isRegistered = false;
//            string checkedSalt = KeyPair.GetCheckedSalt(_salt);
//            KeyPair keyPair = new KeyPair(key);
//            foreach (string hash in _hashList) {
//                if (keyPair.IsValidFor(checkedSalt, hash)) {
//                    _isRegistered = true;
//                    return;
//                }
//            }
        }

        [Obsolete]
        protected void CreateTextFile(string resFileName) {
            int BUFF_LENGTH = 16;
            int STR_LENGTH = 32;
            IList list = new ArrayList();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resFileName))
            using (BinaryReader br = new BinaryReader(stream)) {
                StringBuilder builder = new StringBuilder(0);
                byte[] buff = new byte[BUFF_LENGTH];
                while (buff.Length == BUFF_LENGTH) {
                    builder = new StringBuilder(STR_LENGTH);
                    buff = br.ReadBytes(BUFF_LENGTH);
                    foreach (byte b  in buff)
                        builder.Append(b.ToString("X2"));
                    string value = builder.ToString();
                    if (value.Length > 0)
                        list.Add(value);
                }
            }
            _hashList = new string[list.Count];
            list.CopyTo(_hashList, 0);
        }
        
        int _keyPos;
        StringBuilder _builder;
        protected void CreateTextFileEx(Bitmap image) {
            int posX, posY;
            posX = posY = _keyPos = 0;
            IList list = new ArrayList();
            _builder = new StringBuilder();
            for (int i = 0; i < 1000; i++) {
                Color pixel = image.GetPixel(posX, posY);
                AddByteFor(list, pixel.R);
                AddByteFor(list, pixel.G);
                AddByteFor(list, pixel.B);
                posX++;
                if (posX >= image.Width) {
                    posX = 0;
                    posY++;
                }
            }
            _hashList = new string[list.Count];
            list.CopyTo(_hashList, 0);
        }

        private void AddByteFor(IList list, byte b) {
            GetByteFrom(b, _builder);
            _keyPos++;
            if (_keyPos >= 16) {
                list.Add(_builder.ToString());
                _builder = new StringBuilder();
                _keyPos = 0;
            }
        }

        private static void GetByteFrom(byte colorPart, StringBuilder builder) {
            string toString = colorPart.ToString("X2");
            builder.Append(toString);
        }    
    }
}