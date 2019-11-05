using System;

namespace Dev.config
{
	[Serializable]
	public class ITEMRESOURCE : BaseResource
	{
		/** 道具id */
		public string id;
		/** 道具图标 */
		public string icon;
		/** 道具名字 */
		public string sname;
		/** 道具类型 */
		public int type;
		/** 子类型 */
		public int subtype;
		/** 堆叠上限 */
		public int limit;
		/** 使用效果 */
		public PURPOSE purpose;
	}
	[Serializable]
	public class PURPOSE
	{
		public int add_hp;
		public int add_hp_per;
	}
}