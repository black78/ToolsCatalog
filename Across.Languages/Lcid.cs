// -----------------------------------------------------------------------
// <copyright file="Lcid.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Across.Languages
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using System.Text;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	[StructLayout(LayoutKind.Sequential), ComVisible(true)]
	public struct Lcid
	{
		private short m_langId;
		private byte m_sortId;
		private byte m_reserver;

		#region Constants

		public static readonly short LangNeutral = 0;
		public static readonly short LangInvariant = 0x7f;
		public static readonly short SubLangNeutral = 0;
		public static readonly short SubLangDefault = 1;
		public static readonly short SubLangSysDefault = 2;
		public static readonly byte SortDefault = 0;
		public static readonly byte SortJapaneseXjis = 1;
		public static readonly byte SortJapaneseUnicode = 1;
		public static readonly byte SortChineseBig5 = 0;
		public static readonly byte SortChinesePrcp = 0;
		public static readonly byte SortChineseUnicode = 1;
		public static readonly byte SortChinesePrc = 1;
		public static readonly byte SortChineseBopomofo = 3;
		public static readonly byte SortKoreanKsc = 0;
		public static readonly byte SortKoreanUnicode = 1;
		public static readonly byte SortGermanPhoneBook = 1;
		public static readonly byte SortHungarianDefault = 0;
		public static readonly byte SortHungarianTechnical = 1;
		public static readonly byte SortGeorgianTraditional = 0;
		public static readonly byte SortGeorgianModern = 1;

		public static readonly Lcid LcidNeutral = new Lcid(LangNeutral, SubLangNeutral, SortDefault);
		public static readonly Lcid LcidUserDefault = new Lcid(LangNeutral, SubLangDefault, SortDefault);
		public static readonly Lcid LcidSystemDefault = new Lcid(LangNeutral, SubLangSysDefault, SortDefault);
		public static readonly Lcid LcidInvariant = new Lcid(LangInvariant, SubLangNeutral, SortDefault);

		#endregion

		private static short MakeLangid(short primaryLangId, short subLangId)
		{
			return (short)((((ushort)(subLangId)) << 10) | (ushort)(primaryLangId));
		}

		private static short GetPrimaryLangId(short langId)
		{
			return (short)(((ushort)langId) & 0x3ff);
		}

		private static short GetSubLangId(short langId)
		{
			return (short)(((ushort)langId) >> 10);
		}

		private static int MakeLcid(short langId, byte sortId)
		{
			return (int)((uint)((((uint)((ushort)(sortId))) << 16) | ((uint)((ushort)(langId)))));
		}

		private static short LangIdFromLcid(int lcid)
		{
			return (short)lcid;
		}

		private static byte SortIdFromLcid(int lcid)
		{
			return (byte)((ushort)((((uint)(lcid)) >> 16) & 0xf));
		}

		public Lcid(short primaryLangId, short subLangId, byte sortId)
		{
			this.m_langId = MakeLangid(primaryLangId, subLangId);
			this.m_sortId = sortId;
			this.m_reserver = 0;
		}

		public Lcid(short primaryLangId, short subLangId)
		{
			this.m_langId = MakeLangid(primaryLangId, subLangId);
			this.m_sortId = 0;
			this.m_reserver = 0;
		}

		public Lcid(short langId, byte sortId)
		{
			this.m_langId = langId;
			this.m_sortId = sortId;
			this.m_reserver = 0;
		}

		public Lcid(short langId)
		{
			this.m_langId = langId;
			this.m_sortId = 0;
			this.m_reserver = 0;
		}

		public Lcid(int lcid)
		{
			this.m_langId = (short)lcid;
			this.m_sortId = (byte)((lcid >> 0x10) & 15);
			this.m_reserver = 0;
		}

		public short LangId
		{
			get
			{
				return this.m_langId;
			}
			set
			{
				this.m_langId = value;
			}
		}
		public byte SortId
		{
			get
			{
				return this.m_sortId;
			}
			set
			{
				this.m_sortId = value;
			}
		}
		public short PrimaryLangId
		{
			get
			{
				return GetPrimaryLangId(m_langId);
			}
			set
			{
				m_langId = MakeLangid(value, GetSubLangId(m_langId));
			}
		}
		public short SubLangId
		{
			get
			{
				return GetSubLangId(this.m_langId);
			}
			set
			{
				m_langId = MakeLangid(GetPrimaryLangId(m_langId), value);
			}
		}
		public static implicit operator int(Lcid value)
		{
			return MakeLcid(value.m_langId, value.m_sortId);// ((value.m_sortId << 0x10) | value.m_langId);
		}

		public static implicit operator Lcid(int value)
		{
			return new Lcid
			{
				m_langId = LangIdFromLcid(value),
				m_sortId = SortIdFromLcid(value)
			};
		}

		public static bool operator ==(int x, Lcid y)
		{
			return (x == y.ToInt32());
		}

		public static bool operator !=(int x, Lcid y)
		{
			return (x != y.ToInt32());
		}

		public static bool operator ==(Lcid x, int y)
		{
			return (x.ToInt32() == y);
		}

		public static bool operator !=(Lcid x, int y)
		{
			return (x.ToInt32() != y);
		}

		public static bool operator ==(Lcid x, Lcid y)
		{
			return (x.ToInt32() == y.ToInt32());
		}

		public static bool operator !=(Lcid x, Lcid y)
		{
			return (x.ToInt32() != y.ToInt32());
		}

		private int ToInt32()
		{
			return MakeLcid(m_langId, m_sortId);
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		public override string ToString()
		{
			return this.ToInt32().ToString();
		}

		public override int GetHashCode()
		{
			return this.ToInt32();
		}

		public override bool Equals(object obj)
		{
			if (obj is Lcid)
			{
				return ((Lcid)obj) == this;
			}
			return false;
		}
	}
}
