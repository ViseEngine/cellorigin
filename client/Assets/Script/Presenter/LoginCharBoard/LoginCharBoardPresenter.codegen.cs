﻿// Generated by github.com/davyxu/cellorigin
using UnityEngine;
using UnityEngine.UI;
using System;

partial class LoginCharBoardPresenter : Framework.BasePresenter
{
	LoginCharBoardModel _Model;
	
	NetworkPeer _gamePeer;
	
	public Action OnCharNameChanged;
	public string CharName
	{
		get
		{
			return _Model.CharName;
		}
		set
		{
			_Model.CharName = value;
			
			if ( OnCharNameChanged != null )
			{
				OnCharNameChanged();
			}
		}
	}
	
	public Framework.ObservableCollection<int, LoginCharInfoPresenter> LoginCharList { get; set; }
	
	public void Init( )
	{
		_Model = Framework.ModelManager.Instance.Get<LoginCharBoardModel>();
		
		LoginCharList = new Framework.ObservableCollection<int, LoginCharInfoPresenter>();
		_gamePeer = PeerManager.Instance.Get("game");
		
		_gamePeer.RegisterMessage<gamedef.CharListACK>( obj =>
		{
			Msg_game_CharListACK( _gamePeer, obj as gamedef.CharListACK );
		});
		
	}
	
}
