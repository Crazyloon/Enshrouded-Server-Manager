﻿using Enshrouded_Server_Manager.Models;

namespace Enshrouded_Server_Manager.Events;

public class ProfileSelectedMessage : IApplicationEvent
{
    public ProfileSelectedMessage(ServerProfile selectedProfile)
    {
        this.SelectedProfile = selectedProfile;
    }

    public ServerProfile SelectedProfile { get; private set; }
}