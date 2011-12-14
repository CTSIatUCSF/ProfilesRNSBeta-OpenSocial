using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucModifyNetwork : BaseUserControl
{
    int _profileID = 0;
    List<IProfileUserControlSubscriber> subscribers = new List<IProfileUserControlSubscriber>();

    protected void Page_Load(object sender, EventArgs e)
    {
        _profileID = GetPersonFromQueryString();

        if (!IsPostBack)
        {
            if (_profileID == Profile.ProfileId)
            {
                this.Visible = false;
                return;
            }
            else if (_profileID != 0 && Profile.UserId != 0)
            {
                this.Visible = true;
                Update();
            }
        }
    }

    #region Check box list Event

    protected void chklist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_profileID != 0)
        {
            // Nothing selected-delete all relationships using "Network" keyword
            // Refactor
            if (((CheckBoxList)sender).SelectedIndex == -1)
                _userBL.DeleteUserCheckListItem(Profile.UserId, _profileID, "Network");

            foreach (ListItem li in ((CheckBoxList)sender).Items)
            {
                if (li.Selected)
                    // Handle all of the selected by adding the relationship
                    _userBL.UpdateUserCheckList(Profile.UserId, _profileID, li.Value);
                else
                    // Handle all of the unselected by deleting the relationship
                    _userBL.DeleteUserCheckListItem(Profile.UserId, _profileID, li.Value);
            } 
        }

        Notify();
    }

    #endregion

    #region Load CheckboxList for each different profile
    private void ReCheckListItems(int userId, int personId)
    {
        foreach (DataRow dr in _userBL.GetCheckListForUID(userId, personId).Rows)
        {
            for (int i = 0; i < chklist.Items.Count; i++)
            {
                //relationship_type
                if (chklist.Items[i].Value.Equals(dr["RelationshipType"].ToString()))
                {
                    chklist.Items[i].Selected = true;
                    Session["Flag"] = dr["RelationshipType"].ToString();
                }
            }
        }
    }
    #endregion

    public override void Update()
    {
        chklist.ClearSelection();

        //re-Check checklist items when ever profile changes.
        ReCheckListItems(Profile.UserId, _profileID);

        UpdatePanel up = (UpdatePanel)FindControlRecursive(Page, "pnlMyNetwork");
        up.Update();
    }

}
