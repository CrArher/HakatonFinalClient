﻿using Commands;
using Screens.ScreenChanger;
using UnityEngine;

public class GlobalContext : IGlobalContext
{
    public GlobalContext()
    {
        User = new UserModel();
    }

    public GlobalContext(IGlobalContext context)
    {
        CommandModel = context.CommandModel;
        Mono = context.Mono;
        User = context.User;
    }

    public MonoBehaviour Mono { get; set; }
    public CommandModel CommandModel { get; set; }
    public ScreenChangerModel ScreenChangerModel { get; set; }
    public UserModel User { get; set; }
}