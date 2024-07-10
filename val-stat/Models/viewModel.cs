using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

public class MainViewModel : ObservableObject
{
    private ObservableCollection<string> _users;

    public ObservableCollection<string> Users
    {
        get => _users;
        set => SetProperty(ref _users, value);
    }
    private ObservableCollection<string> _userpp;

    public ObservableCollection<string> Userpp
    {
        get => _userpp;
        set => SetProperty(ref _userpp, value);
    }

    public MainViewModel()
    {
        Users = new ObservableCollection<string>
        {
        };
        Userpp = new ObservableCollection<string>
        {
        };
    }
    public void AddUser(string user)
    {
        if (!Users.Contains(user))
        {
            Users.Add(user);
        }
    }

    public void AddUserpp(string userProfilePicture)
    {
        if (!Userpp.Contains(userProfilePicture))
        {
            Userpp.Add(userProfilePicture);
        }
    }
}
