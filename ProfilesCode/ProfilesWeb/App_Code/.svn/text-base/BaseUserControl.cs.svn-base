using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

/// <summary>
/// Summary description for BaseUserControl
/// </summary>
public class BaseUserControl : System.Web.UI.UserControl, IProfileUserControlPublisher, IProfileUserControlSubscriber 
{
    // Private fields used for BL access
    protected UserBL _userBL = new UserBL();
    List<IProfileUserControlSubscriber> _subscribers = new List<IProfileUserControlSubscriber>();
    private bool _hasData = false;

    public BaseUserControl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool HasData
    {
        get { return _hasData; }
        set { _hasData = value; }
    }

    public Control FindControlRecursive(Control container, string name)
    {
        if (container.ID == name)
            return container;

        foreach (Control ctrl in container.Controls)
        {
            Control foundCtrl = FindControlRecursive(ctrl, name);
            if (foundCtrl != null)
                return foundCtrl;
        }
        return null;
    }

    protected int GetPersonFromQueryString()
    {
        int personId = 0;

        if (Request["Person"] != null)
        {
            if (!int.TryParse(Request["Person"], out personId))
            {
                personId = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonIdFromInternalId("EcommonsUsername", Request["Person"]);
            }
        }

        return personId;
    }

    #region Events for User Control Synchronization

    protected void Notify()
    {
        foreach (IProfileUserControlSubscriber subscriber in _subscribers)
        {
            subscriber.Update();
        }
    }

    public void Subscribe(IProfileUserControlSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void SubscribeBiDirectional(IProfileUserControlSubscriber subscriber)
    {
        // Add the control to the list of subscribers
        _subscribers.Add(subscriber);
        // Since this bi-directional, make the publisher a subscriber of this control
        ((IProfileUserControlPublisher)subscriber).Subscribe(this);
    }

    virtual public void Update() { }

    #endregion
}
