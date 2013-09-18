using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Bronze.Controls.VWG.Common
{
    public class LZWData
    {
        public string str;
        public int val;
        public int position;
        public int index;
    }
    public static partial class LZStringCompress
    {
        static string _keyStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        public static String fromCharCode(params char[] codePoints)
        {
            return new String(codePoints, 0, codePoints.Length);
        }

        public static char f(int code)
        {
            return Convert.ToChar(code);
        }

        public static string Decompress(string compressed)
        {
            if (compressed == null)
                throw new ArgumentNullException("compressed");
            var dictionary = new Dictionary<int, string>();
            int next;
            int enlargeIn = 4;
            int dictSize = 4;
            int numBits = 3;
            var entry = "";
            var result = "";
            int i;
            string w;
            int bits, resb, maxpower, power;
            string c = "";
            //f = this._f,
            var data = new LZWData
            {
                str = compressed,
                val = compressed.charCodeAt(0),
                position = 32768,
                index = 1
            };

            for (i = 0; i < 3; i += 1)
            {
                dictionary[i] = i.ToString();
            }

            bits = 0;
            maxpower = Convert.ToInt32(Math.Pow(2, 2));
            power = 1;
            while (power != maxpower)
            {
                resb = data.val & data.position;
                data.position >>= 1;
                if (data.position == 0)
                {
                    data.position = 32768;
                    data.val = data.str.charCodeAt(data.index++);
                }
                bits |= (resb > 0 ? 1 : 0) * power;
                power <<= 1;
            }

            switch (next = bits)
            {
                case 0:
                    bits = 0;
                    maxpower = Convert.ToInt32(Math.Pow(2, 8));
                    power = 1;
                    while (power != maxpower)
                    {
                        resb = data.val & data.position;
                        data.position >>= 1;
                        if (data.position == 0)
                        {
                            data.position = 32768;
                            data.val = data.str.charCodeAt(data.index++);
                        }
                        bits |= (resb > 0 ? 1 : 0) * power;
                        power <<= 1;
                    }
                    c = f(bits).ToString();
                    break;
                case 1:
                    bits = 0;
                    maxpower = Convert.ToInt32(Math.Pow(2, 16));
                    power = 1;
                    while (power != maxpower)
                    {
                        resb = data.val & data.position;
                        data.position >>= 1;
                        if (data.position == 0)
                        {
                            data.position = 32768;
                            data.val = data.str.charCodeAt(data.index++);
                        }
                        bits |= (resb > 0 ? 1 : 0) * power;
                        power <<= 1;
                    }
                    c = f(bits).ToString();
                    break;
                case 2:
                    return "";
            }
            dictionary[3] = c.ToString();
            w = result = c.ToString();
            while (true)
            {
                bits = 0;
                maxpower = Convert.ToInt32(Math.Pow(2, numBits));
                power = 1;
                while (power != maxpower)
                {
                    resb = data.val & data.position;
                    data.position >>= 1;
                    if (data.position == 0)
                    {
                        data.position = 32768;
                        data.val = data.str.charCodeAt(data.index++);
                    }
                    bits |= (resb > 0 ? 1 : 0) * power;
                    power <<= 1;
                }

                switch (c = bits.ToString())
                {
                    case "0":
                        bits = 0;
                        maxpower = Convert.ToInt32(Math.Pow(2, 8));
                        power = 1;
                        while (power != maxpower)
                        {
                            resb = data.val & data.position;
                            data.position >>= 1;
                            if (data.position == 0)
                            {
                                data.position = 32768;
                                data.val = data.str.charCodeAt(data.index++);
                            }
                            bits |= (resb > 0 ? 1 : 0) * power;
                            power <<= 1;
                        }

                        dictionary[dictSize++] = f(bits).ToString();
                        c = (dictSize - 1).ToString();
                        enlargeIn--;
                        break;
                    case "1":
                        bits = 0;
                        maxpower = Convert.ToInt32(Math.Pow(2, 16));
                        power = 1;
                        while (power != maxpower)
                        {
                            resb = data.val & data.position;
                            data.position >>= 1;
                            if (data.position == 0)
                            {
                                data.position = 32768;
                                data.val = data.str.charCodeAt(data.index++);
                            }
                            bits |= (resb > 0 ? 1 : 0) * power;
                            power <<= 1;
                        }
                        dictionary[dictSize++] = f(bits).ToString();
                        c = (dictSize - 1).ToString();
                        enlargeIn--;
                        break;
                    case "2":
                        return result;
                }

                if (enlargeIn == 0)
                {
                    enlargeIn = Convert.ToInt32(Math.Pow(2, numBits));
                    numBits++;
                }

                int cc = 0;
                if (int.TryParse(c, out cc) && dictionary.ContainsKey(cc) && dictionary[cc].NotNull())
                {
                    entry = dictionary[cc].ToString();
                }
                else
                {
                    if (c == dictSize.ToString())
                    {
                        entry = w + w[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                result += entry;

                // Add w+entry[0] to the dictionary.
                dictionary[dictSize++] = w + entry[0];
                enlargeIn--;

                w = entry;

                if (enlargeIn == 0)
                {
                    enlargeIn = Convert.ToInt32(Math.Pow(2, numBits));
                    numBits++;
                }

            }
        }

        //public static string DecompressFromBase64(string input)
        //{
        //    var data = System.Convert.FromBase64String(input);
        //    var realData = Encoding.UTF8.GetString(data);
        //    return Decompress(realData);
        //}

        public static string DecompressFromUTF16(string input)
        {
            if (input == null) return "";
            var output = "";
            int current = 0;
            int c;
            int status = 0;
            int i = 0;


            while (i < input.Length)
            {
                c = input.charCodeAt(i) - 32;

                switch (status++)
                {
                    case 0:
                        current = c << 1;
                        break;
                    case 1:
                        output += f(current | (c >> 14));
                        current = (c & 16383) << 2;
                        break;
                    case 2:
                        output += f(current | (c >> 13));
                        current = (c & 8191) << 3;
                        break;
                    case 3:
                        output += f(current | (c >> 12));
                        current = (c & 4095) << 4;
                        break;
                    case 4:
                        output += f(current | (c >> 11));
                        current = (c & 2047) << 5;
                        break;
                    case 5:
                        output += f(current | (c >> 10));
                        current = (c & 1023) << 6;
                        break;
                    case 6:
                        output += f(current | (c >> 9));
                        current = (c & 511) << 7;
                        break;
                    case 7:
                        output += f(current | (c >> 8));
                        current = (c & 255) << 8;
                        break;
                    case 8:
                        output += f(current | (c >> 7));
                        current = (c & 127) << 9;
                        break;
                    case 9:
                        output += f(current | (c >> 6));
                        current = (c & 63) << 10;
                        break;
                    case 10:
                        output += f(current | (c >> 5));
                        current = (c & 31) << 11;
                        break;
                    case 11:
                        output += f(current | (c >> 4));
                        current = (c & 15) << 12;
                        break;
                    case 12:
                        output += f(current | (c >> 3));
                        current = (c & 7) << 13;
                        break;
                    case 13:
                        output += f(current | (c >> 2));
                        current = (c & 3) << 14;
                        break;
                    case 14:
                        output += f(current | (c >> 1));
                        current = (c & 1) << 15;
                        break;
                    case 15:
                        output += f(current | c);
                        status = 0;
                        break;
                }

                i++;
            }

            return Decompress(output);
            //return output;
        }


        public static string DecompressFromBase64(string input)
        {
            if (input == null) return "";
            var output = "";
            var ol = 0;
            char output_ = default(char);
            int chr1, chr2, chr3;
            int enc1, enc2, enc3, enc4;
            var i = 0;

            input = Regex.Replace(input, @"[^A-Za-z0-9\+\/\=]", "");
            //input = input.Replace(/[^A-Za-z0-9\+\/\=]/g, "");

            while (i < input.Length)
            {
                enc1 = _keyStr.IndexOf(input.charAt(i++));
                enc2 = _keyStr.IndexOf(input.charAt(i++));
                enc3 = _keyStr.IndexOf(input.charAt(i++));
                enc4 = _keyStr.IndexOf(input.charAt(i++));

                chr1 = (enc1 << 2) | (enc2 >> 4);
                chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
                chr3 = ((enc3 & 3) << 6) | enc4;

                if (ol % 2 == 0)
                {
                    output_ = (char)(chr1 << 8);

                    if (enc3 != 64)
                    {
                        output += f(output_ | chr2);
                    }
                    if (enc4 != 64)
                    {
                        output_ = (char)(chr3 << 8);
                    }
                }
                else
                {
                    output = output + f(output_ | chr1);

                    if (enc3 != 64)
                    {
                        output_ = (char)(chr2 << 8);
                    }
                    if (enc4 != 64)
                    {
                        output += f(output_ | chr3);
                    }
                }
                ol += 3;
            }

            return Decompress(output);
        }


    }
}