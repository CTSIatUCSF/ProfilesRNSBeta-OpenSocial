/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class MyNetwork : BasePageSecure
{
    private string strRedirectURL = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Profile.UserId != null)
            {
                //BindDataToGrids;
                BindCollaborators(Profile.UserId);

                BindCurrentAdvisor(Profile.UserId);
                BindPastAdvisor(Profile.UserId);

                BindCurrentAdvisee(Profile.UserId);
                BindPastAdvisee(Profile.UserId);

                // Hide the My Network control on the left
                UserControl ucMyNetwork = (UserControl)FindControlRecursive(Master, "ucMyNetwork");
                ucMyNetwork.Visible = false;
            }
        }

        // Make sure the right panel is hidden
        HideRightColumn();
    }


    #region Bind Data to Grid
    /// <summary>
    /// Bind Data To Grid Collaborators
    /// </summary>
    /// <param name="veiwerUID"></param>
    private void BindCollaborators(int personId)
    {
        //Bind Grid Collaborators
        grdCollaborators.DataSource = _userBL.GetUserCollaborators(personId);
        grdCollaborators.DataBind();
        lblCollaborator.Text = "<b>Collaborators/Colleagues</b> (" + grdCollaborators.Rows.Count + ")";
    }

    /// <summary>
    /// Bind Data to Grid current Advisor
    /// </summary>
    /// <param name="veiwerUID"></param>
    private void BindCurrentAdvisor(int personId)
    {
        //Bind Grid Current Advisor
        grdCurrentAdvisor.DataSource = _userBL.GetUserCurrentAdvisors(personId);
        grdCurrentAdvisor.DataBind();
        lblCurrentAdvisors.Text = "<b>Advisors (Current)</b> (" + grdCurrentAdvisor.Rows.Count + ")";
    }

    /// <summary>
    /// Bind Data To Grid PastAdvisor
    /// </summary>
    /// <param name="veiwerUID"></param>
    private void BindPastAdvisor(int personId)
    {
        grdPastAdvisor.DataSource = _userBL.GetUserPastAdvisors(personId);
        grdPastAdvisor.DataBind();
        lblPastAdvisors.Text = "<b>Advisors (Past)</b> (" + grdPastAdvisor.Rows.Count + ")";
    }

    /// <summary>
    /// Bind Data to Current Advisee
    /// </summary>
    /// <param name="veiwetUID"></param>
    private void BindCurrentAdvisee(int personId)
    {
        grdCurrentAdvisee.DataSource = _userBL.GetUserCurrentAdvisees(personId);
        grdCurrentAdvisee.DataBind();
        lblCurrentAdvisees.Text = "<b>Advisees (Current)</b> (" + grdCurrentAdvisee.Rows.Count + ")";
    }

    /// <summary>
    /// Bind Data to past Advisee
    /// </summary>
    /// <param name="veiwetUID"></param>
    private void BindPastAdvisee(int personId)
    {
        grdPastAdvisee.DataSource = _userBL.GetUserPastAdvisees(personId);
        grdPastAdvisee.DataBind();
        lblPastAdvisees.Text = "<b>Advisees (Past)</b> (" + grdPastAdvisee.Rows.Count + ")";
    }
    #endregion

    private void UpdateLeftNav()
    {
        //Update Left Nav  Network List
        UpdatePanel pnlNetwork = (UpdatePanel)FindControlRecursive(Master, "pnlMyNetwork");
        pnlNetwork.Update();
    }

    #region grdCollaborators: OnRowCreated, OnRowDeleting

    #region OnRowCreated
    protected void grdCollaborators_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["Collaborator"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkCollaborators"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();
                }
            }
        }

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    #endregion

    #region OnRowDeleting
    protected void grdCollaborators_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (Profile.UserId != 0)
        {
            _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdCollaborators.DataKeys[e.RowIndex].Value), "Collaborator");
            //Update Left Nav  Network List
            UpdateLeftNav();
            //BindDataToGrids;
            BindCollaborators(Profile.UserId);
            BindCurrentAdvisor(Profile.UserId);
            BindPastAdvisor(Profile.UserId);
            BindCurrentAdvisee(Profile.UserId);
            BindPastAdvisee(Profile.UserId);
        }
        else
        {
            Response.Redirect(strRedirectURL);
        }
    }
    #endregion

    #endregion

    #region grdCurrentAdvisor: OnRowCreated, OnRowDeleting

    #region OnRowCreated
    protected void grdCurrentAdvisor_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["CurrentAdvisor"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkCurrentAdvisor"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion

    #region OnRowDeleting
    protected void grdCurrentAdvisor_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Profile.UserId != null)
            {
                _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdCurrentAdvisor.DataKeys[e.RowIndex].Value), "CurrentAdvisor");
                //Update Left Nav  Network List
                UpdateLeftNav();
                //BindDataToGrids;
                BindCollaborators(Profile.UserId);
                BindCurrentAdvisor(Profile.UserId);
                BindPastAdvisor(Profile.UserId);
                BindCurrentAdvisee(Profile.UserId);
                BindPastAdvisee(Profile.UserId);
            }
            else
            {
                Response.Redirect(strRedirectURL);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }

    }
    #endregion

    #endregion

    #region Grid grdPastAdvisor: : OnRowCreated, OnRowDeleting

    #region OnRowCreated
    protected void grdPastAdvisor_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["PastAdvisor"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkPastAdvisor"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion

    #region OnRowDeleting
    protected void grdPastAdvisor_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Profile.UserId != null)
            {
                _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdPastAdvisor.DataKeys[e.RowIndex].Value), "PastAdvisor");
                //Update Left Nav  Network List
                UpdateLeftNav();    
                //BindDataToGrids;
                BindCollaborators(Profile.UserId);
                BindCurrentAdvisor(Profile.UserId);
                BindPastAdvisor(Profile.UserId);
                BindCurrentAdvisee(Profile.UserId);
                BindPastAdvisee(Profile.UserId);
            }
            else
            {
                Response.Redirect(strRedirectURL);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    #endregion

    #endregion

    #region Grid grdCurrentAdvisee: OnRowCreated, OnRowDeleting

    #region OnRowCreated
    protected void grdCurrentAdvisee_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["CurrentAdvisee"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkCurrentAdvisee"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion

    #region OnRowDeleting
    protected void grdCurrentAdvisee_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Profile.UserId != null)
            {
                _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdCurrentAdvisee.DataKeys[e.RowIndex].Value), "CurrentAdvisee");
                //Update Left Nav  Network List
                UpdateLeftNav();
                //BindDataToGrids;
                BindCollaborators(Profile.UserId);
                BindCurrentAdvisor(Profile.UserId);
                BindPastAdvisor(Profile.UserId);
                BindCurrentAdvisee(Profile.UserId);
                BindPastAdvisee(Profile.UserId);
            }
            else
            {
                Response.Redirect(strRedirectURL);
            }
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
    }
    #endregion

    #endregion

    #region Grid grdPastAdvisee: OnRowCreated, OnRowDeleting
    #region OnRowCreated
    protected void grdPastAdvisee_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["PastAdvisee"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkPastAdvisee"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion

    #region OnRowDeleting
    protected void grdPastAdvisee_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Profile.UserId != null)
            {
                _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdPastAdvisee.DataKeys[e.RowIndex].Value), "PastAdvisee");
                //Update Left Nav  Network List
                UpdateLeftNav();
                //BindDataToGrids;
                BindCollaborators(Profile.UserId);
                BindCurrentAdvisor(Profile.UserId);
                BindPastAdvisor(Profile.UserId);
                BindCurrentAdvisee(Profile.UserId);
                BindPastAdvisee(Profile.UserId);
            }
            else
            {
                Response.Redirect(strRedirectURL);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }
    #endregion
    #endregion
}
