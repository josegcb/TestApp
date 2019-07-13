﻿using Library.Extenders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Helpers {
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

        public static string GetDescription(Enum valValue, int valIndex) {
            if (valValue == null) {
                throw new ArgumentNullException("value");
            }
            return valValue.GetDescription(valIndex);
        }

        public static IList ToList(Type valEnumType, int valIndex) {
            if (valEnumType == null) {
                throw new ArgumentNullException("type");
            }
            if (!valEnumType.IsEnum) {
                throw new ArgumentException(string.Format("El tipo {0}, debe ser enumerativo.", valEnumType.Name));
            }
            ArrayList vList = new ArrayList();
            Array vEnumValues = Enum.GetValues(valEnumType);
            foreach (Enum vValue in vEnumValues) {
                vList.Add(new KeyValuePair<Enum, string>(vValue, GetDescription(vValue, valIndex)));
            }
            return vList;
        }
    }
}
