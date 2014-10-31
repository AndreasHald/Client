using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for encryption
/// </summary>
public class encryption
{

    public string EncryptDecrypt(string textToEncrypt)
    {
        configuration cf = new configuration();
        StringBuilder inSb = new StringBuilder(textToEncrypt);
        StringBuilder outSb = new StringBuilder(textToEncrypt.Length);

        char c;

        for (int i = 0; i < textToEncrypt.Length; i++)
        {

            c = inSb[i];

            c = (char)(c ^ cf.getEncryptionkey());

            outSb.Append(c);

        }

        return outSb.ToString();
    }
}