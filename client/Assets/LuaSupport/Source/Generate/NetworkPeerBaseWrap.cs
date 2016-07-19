﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class NetworkPeerBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NetworkPeerBase), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Stop", Stop);
		L.RegFunction("Connect", Connect);
		L.RegFunction("PostStream", PostStream);
		L.RegFunction("Polling", Polling);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", Lua_ToString);
		L.RegVar("_name", get__name, set__name);
		L.RegVar("Address", get_Address, set_Address);
		L.RegVar("DebugMessage", get_DebugMessage, set_DebugMessage);
		L.RegVar("Name", get_Name, set_Name);
		L.RegVar("EmulateDelayMS", get_EmulateDelayMS, set_EmulateDelayMS);
		L.RegVar("Valid", get_Valid, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)ToLua.CheckObject(L, 1, typeof(NetworkPeerBase));
			obj.Stop();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Connect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			NetworkPeerBase obj = (NetworkPeerBase)ToLua.CheckObject(L, 1, typeof(NetworkPeerBase));
			string arg0 = ToLua.CheckString(L, 2);
			obj.Connect(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PostStream(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			NetworkPeerBase obj = (NetworkPeerBase)ToLua.CheckObject(L, 1, typeof(NetworkPeerBase));
			uint arg0 = (uint)LuaDLL.luaL_checknumber(L, 2);
			System.IO.MemoryStream arg1 = (System.IO.MemoryStream)ToLua.CheckObject(L, 3, typeof(System.IO.MemoryStream));
			obj.PostStream(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Polling(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)ToLua.CheckObject(L, 1, typeof(NetworkPeerBase));
			obj.Polling();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);

		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string ret = obj._name;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index _name on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Address(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string ret = obj.Address;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Address on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMessage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			bool ret = obj.DebugMessage;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DebugMessage on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string ret = obj.Name;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Name on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EmulateDelayMS(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			uint ret = obj.EmulateDelayMS;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index EmulateDelayMS on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Valid(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			bool ret = obj.Valid;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Valid on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj._name = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index _name on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Address(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.Address = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Address on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DebugMessage(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.DebugMessage = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DebugMessage on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.Name = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Name on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_EmulateDelayMS(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			NetworkPeerBase obj = (NetworkPeerBase)o;
			uint arg0 = (uint)LuaDLL.luaL_checknumber(L, 2);
			obj.EmulateDelayMS = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index EmulateDelayMS on a nil value" : e.Message);
		}
	}
}
