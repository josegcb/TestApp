using Library.Extenders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helpers {

    public static class EnumHelper {
        public static string GetDescription(Enum valValue, int valIndex) {
            if (valValue == null) {
                throw new ArgumentNullException("value");
            }
            return valValue.GetDescription(valIndex);
        }

        public static List<EnumJson> ToList(string valEnumName) {
            Type T = GetType(valEnumName);
            return ToList(T, 0);
        }

        public static List<EnumJson> ToList(Type valEnumType, int valIndex) {
            if (valEnumType == null) {
                throw new ArgumentNullException("type");
            }
            if (!valEnumType.IsEnum) {
                throw new ArgumentException(string.Format("El tipo {0}, debe ser enumerativo.", valEnumType.Name));
            }            
            Array vEnumValues = Enum.GetValues(valEnumType);
            List<EnumJson> vList = new List<EnumJson>(vEnumValues.Length);
            foreach (object vItem in vEnumValues) {
                Enum vEnum = vItem as Enum;
                if (vEnum != null) {
                    string vDes = vEnum.GetDescription();
                    if (!string.IsNullOrEmpty(vDes)) {
                        vList.Add(new EnumJson((int)vItem, vDes));
                    }
                }                
            }
            return vList;
        }
        private static Type GetType(string enumName) {
            var x = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                var x1 = assembly.GetTypes();
                var type = assembly.GetType(enumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }
            return null;
        }

    }
    public static class EnumHelper<EnumType> where EnumType : struct, IComparable, IConvertible, IFormattable {
        public static List<EnumJson> GetDescriptions() {
            if (!typeof(EnumType).IsEnum) {
                throw new ArgumentException(string.Format("El tipo {0}, debe ser enumerativo.", typeof(EnumType).Name));
            }
            Array vValues = Enum.GetValues(typeof(EnumType));
            List<EnumJson> vList = new List<EnumJson>(vValues.Length);
            foreach (object vItem in vValues) {
                Enum vEnum = vItem as Enum;
                if (vEnum != null) {
                    string vDes = vEnum.GetDescription();
                    if (!string.IsNullOrEmpty(vDes)) {
                        vList.Add(new EnumJson((int)vItem, vDes));
                    }
                }
            }
            return vList;
        }       
    }
}
