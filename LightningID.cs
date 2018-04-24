using System;
using System.Collections.Generic;
using System.Linq;

namespace BT.Core.Util {
	public static class LightningID {
		/// <summary>
		/// Convert a 15 character SF Classic ID to an 18 digit SF Lightning ID.
		/// </summary>
		/// <remarks> 
		/// See http://forceguru.blogspot.com/2010/12/how-salesforce-18-digit-id-is.html for more detail
		/// </remarks>
		public static string FromClassicID(string classicID) {
			string suffix = "";

			for (int i = 0; i < 3; i++) {
				int flags = 0;
				for (int j = 0; j < 5; j++) {
					var c = classicID.Substring(i * 5 + j, 1);

					if (c.ToUpper().Equals(c) && c.All(char.IsLetter)) {
						flags = flags + (1 << j);
					}
				}
				if (flags <= 25) {
					suffix = suffix + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(flags, 1);
				} else {
					suffix = suffix + "012345".Substring(flags - 26, 1);
				}
			}
			return classicID + suffix;
		}
	}
}