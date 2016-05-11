﻿// Generated by github.com/davyxu/cellorigin
using UnityEngine;
using UnityEngine.UI;

partial class LoginView : Framework.BaseView
{
	LoginPresenter _Presenter;
	
	InputField _Account;
	InputField _Address;
	Button _SetDevAddress;
	Button _SetPublicAddress;
	Framework.ListControl _LoginServerList;
	
	public override void Bind( Framework.BasePresenter presenter )
	{
		_Presenter = presenter as LoginPresenter;
		
		var trans = this.transform;
		
		_Account = trans.Find("Account").GetComponent<InputField>();
		_Address = trans.Find("Address").GetComponent<InputField>();
		_SetDevAddress = trans.Find("SetDevAddress").GetComponent<Button>();
		_SetPublicAddress = trans.Find("SetPublicAddress").GetComponent<Button>();
		_LoginServerList = trans.Find("LoginServerList").GetComponent<Framework.ListControl>();
		
		_Account.onValueChanged.AddListener( x =>
		{
			_Presenter.Account = x;
		} );
		_Presenter.Account = _Account.text;
		_Presenter.OnAccountChanged += delegate()
		{
			_Account.text = _Presenter.Account;
		};
		if ( _Presenter.Account != null )
		{
			_Account.text = _Presenter.Account;
		}
		
		_Presenter.OnAddressChanged += delegate()
		{
			_Address.text = _Presenter.Address;
		};
		if ( _Presenter.Address != null )
		{
			_Address.text = _Presenter.Address;
		}
		
		_SetDevAddress.onClick.AddListener( _Presenter.Cmd_SetDevAddress );
		_SetPublicAddress.onClick.AddListener( _Presenter.Cmd_SetPublicAddress );
		Framework.Utility.BindCollection<int, LoginServerInfoPresenter, LoginServerInfoView>( _Presenter.LoginServerList, _LoginServerList );
		
	}
	
}
