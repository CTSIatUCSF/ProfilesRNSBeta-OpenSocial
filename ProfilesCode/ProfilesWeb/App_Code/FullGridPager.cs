using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


/// <summary>
/// Summary description for FullGridPager
/// FullGridPager is a very nice and complete custom pager to use inside a GridView's PagerTemplate.
/// Images files:
///     Images/firstpage.gif
///     Images/prevpage.gif
///     Images/nextpage.gif
///     Images/lastpage.gif
/// CSS:
///     .pagerOuterTable    : the style of the html table.
///     .pageCounter        : the style of the first table cell "Page 1 of N".
///     .pageFirstLast      : the style of the First and Last cells.
///     .pagerLink          : the style of the page number links.
///     .pagePrevNextNumber : the style of the Previous, Next and page Number cells.
///     .pageCurrentNumber  : the style of the currently selected page number link.
///     .pageGroups         : the style of the page groups cell.
/// Parameters:
///     MaxVisiblePageNumbers   : the number of VISIBLE page links.
///     PageCounterText         : the text to display at the beginning of the page counter.
///     PageCounterTotalText    : the text to display before the count of pages inside the page counter.
///     TheGrid                 : the gridview control.
///     
/// Written by dpant@yahoo.com, 06-10-07
/// </summary>
public class FullGridPager
{
    private const int DEFAULT_MAX_VISIBLE = 0;
    private const string DEFAULT_COUNTER_TEXT = "Σελίδα";
    private const string DEFAULT_TOTAL_TEXT = "από";

    protected int maxVisiblePageNumbers;
    private int totalRowCount;
    protected int firstPageNumber;
    protected int lastPageNumber;
    protected string pageCounterText;
    protected string pageCounterTotalText;
    protected GridView theGrid;
    protected GridViewRow theGridViewRow;

    public FullGridPager(GridView TheGrid)
    {
        // Default Constructor		
        maxVisiblePageNumbers = DEFAULT_MAX_VISIBLE;
        pageCounterText = DEFAULT_COUNTER_TEXT;
        pageCounterTotalText = DEFAULT_TOTAL_TEXT;
        theGrid = TheGrid;
    }

    public FullGridPager(GridView TheGrid, int MaxVisible, string CounterText, string TotalText)
    {
        // Parameterized constructor
        maxVisiblePageNumbers = MaxVisible;
        pageCounterText = CounterText;
        pageCounterTotalText = TotalText;
        theGrid = TheGrid;

        // Temporary 
        theGrid.PageSize = 20;
    }

    public int MaxVisiblePageNumbers
    {
        get { return maxVisiblePageNumbers; }
        set { maxVisiblePageNumbers = value; }
    }

    public int TotalRowCount
    {
        get { return totalRowCount; }
        set { totalRowCount = value; }
    }

    public string PageCounterText
    {
        get { return pageCounterText; }
        set { pageCounterText = value; }
    }

    public string PageCounterTotalText
    {
        get { return pageCounterTotalText; }
        set { pageCounterTotalText = value; }
    }

    public GridView TheGrid
    {
        get { return theGrid; }
    }

    public void CreateCustomPager(GridViewRow PagerRow)
    {
        // Create custom pager inside the Grid's pagerTemplate.
        // An html table is used to format the custom pager.

        // No data to display.
        if (PagerRow == null) return;

        theGridViewRow = PagerRow;

        HtmlTable pagerInnerTable = (HtmlTable)PagerRow.Cells[0].FindControl("pagerInnerTable");
        HtmlTable pagerCounterTable = (HtmlTable)PagerRow.Cells[0].FindControl("pagerCounterTable");
        //HtmlTable pagerNumberTable = (HtmlTable)PagerRow.Cells[0].FindControl("pagerNumberTable");

        if (pagerInnerTable != null)
        {
            // default dynamic cell position. 
            // (after the pageCount, the "First" and the "Previous" cells).            
            int insertCellPosition = 0;
            if (theGrid.PageIndex == 0)
            {
                LinkButton lnkFirstPage = (LinkButton)pagerInnerTable.FindControl("lnkFirstPage");
                LinkButton lnkPrevPage = (LinkButton)pagerInnerTable.FindControl("lnkPrevPage");

                // The first page is currently displayed.
                // Hide First and Previous page navigation.
                //pagerInnerTable.Rows[0].Cells[1].Visible = false;
                //pagerInnerTable.Rows[0].Cells[2].Visible = false;
                lnkFirstPage.Enabled = false;
                lnkPrevPage.Enabled = false;

                // Change the default dynamic cell to 1.
                //insertCellPosition = 0;
            }

            CalcFirstPageNumber();
            CalcLastPageNumber();

            //CreatePageNumbers(pagerNumberTable, insertCellPosition);

            int lastCellPosition = pagerInnerTable.Rows[0].Cells.Count - 1;
            if (theGrid.PageIndex == theGrid.PageCount - 1)
            {
                LinkButton lnkNextPage = (LinkButton)pagerInnerTable.FindControl("lnkNextPage");
                LinkButton lnkLastPage = (LinkButton)pagerInnerTable.FindControl("lnkLastPage");

                // The last page is currently displayed.
                // Hide Next and Last page navigation.                
                //pagerInnerTable.Rows[0].Cells[lastCellPosition - 1].Visible = false;
                //pagerInnerTable.Rows[0].Cells[lastCellPosition].Visible = false;
                lnkNextPage.Enabled = false;
                lnkLastPage.Enabled = false;
            }

            //// Control the visibility of the page group links
            //if (theGrid.PageIndex < MaxVisiblePageNumbers)
            //{
            //    LinkButton lnkPrevPageGroup = (LinkButton)pagerNumberTable.FindControl("lnkPrevPageGroup");
            //    lnkPrevPageGroup.Visible = false;
            //}
            //if ((theGrid.PageIndex + MaxVisiblePageNumbers) > theGrid.PageCount)
            //{
            //    LinkButton lnkNextPageGroup = (LinkButton)pagerNumberTable.FindControl("lnkNextPageGroup");
            //    lnkNextPageGroup.Visible = false;
            //}

            UpdatePageCounter(pagerInnerTable);
        }
    }

    private void CreatePageNumbers(HtmlTable pagerInnerTable, int insertCellPosition)
    {
        for (int i = firstPageNumber, pos = 1; i <= lastPageNumber; i++, pos++)
        {
            // Create a new table cell for every data page number.
            HtmlTableCell tableCell = new HtmlTableCell();
            if (theGrid.PageIndex == i - 1)
                tableCell.Attributes.Add("class", "pageCurrentNumber");
            else
                tableCell.Attributes.Add("class", "pagePrevNextNumber");

            // Create a new LinkButton for every data page number.
            LinkButton lnkPage = new LinkButton();
            lnkPage.ID = "Page" + i.ToString();
            lnkPage.Text = i.ToString();
            lnkPage.CommandName = "Page";
            lnkPage.CommandArgument = i.ToString();
            lnkPage.CssClass = "pagerLink";

            // Place link inside the table cell; Add the cell to the table row.                
            tableCell.Controls.Add(lnkPage);
            pagerInnerTable.Rows[0].Cells.Insert(insertCellPosition + pos, tableCell);
        }
    }

    private void CalcFirstPageNumber()
    {
        // Calculate the first, visible page number of the pager.             
        firstPageNumber = 1;
        if (MaxVisiblePageNumbers == DEFAULT_MAX_VISIBLE)
            MaxVisiblePageNumbers = theGrid.PageCount;

        if (theGrid.PageCount > MaxVisiblePageNumbers)
        {
            // Seperate page numbers in groups if necessary.
            if ((theGrid.PageIndex + 1) > maxVisiblePageNumbers)
            {
                // Calculate the group to display.
                // Example: 
                //      GridView1.PageCount = 12
                //      maxVisiblePageNumbers = 4
                //      GridView1.PageIndex+1 = 7
                //      --> pageGroup = 2       (Page numbers: 5, 6, 7, 8)
                decimal pageGroup = Math.Ceiling((decimal)(theGrid.PageIndex + 1) / MaxVisiblePageNumbers);
                // Calculate the first page number for the group to display.
                // Example :
                //      if pageGroup = 1 (Page numbers: 1,2,3,4) --> firstPageNumber = 1
                //      if pageGroup = 2 (Page numbers: 5,6,7,8) --> firstPageNumber = 5
                //      if pageGroup = 3 (Page numbers: 9,10,11,12) --> firstPageNumber = 9                        
                firstPageNumber = (int)(1 + (MaxVisiblePageNumbers * (pageGroup - 1)));
            }
        }
    }

    private void CalcLastPageNumber()
    {
        // Calculate the last, visible page number of the pager.
        lastPageNumber = theGrid.PageCount;
        if (MaxVisiblePageNumbers == DEFAULT_MAX_VISIBLE)
            MaxVisiblePageNumbers = theGrid.PageCount;

        if (theGrid.PageCount > MaxVisiblePageNumbers)
        {
            lastPageNumber = firstPageNumber + (MaxVisiblePageNumbers - 1);
            if (theGrid.PageCount < lastPageNumber)
                lastPageNumber = theGrid.PageCount;
        }
    }

    private void UpdatePageCounter(HtmlTable pagerInnerTable)
    {
        // Display current page number and total number of pages.     
        Label pageCounter = (Label)pagerInnerTable.Rows[0].Cells[0].FindControl("lblPageCounter");
        int startRow = (theGrid.PageIndex * theGrid.PageSize) + 1;
        int endRow = startRow + theGrid.PageSize - 1;

        // Make sure we don't exceed the total row count
        if (endRow > TotalRowCount)
            endRow = TotalRowCount;

        pageCounter.Text = "&nbsp;" + PageCounterText + "&nbsp;" + startRow.ToString() + "&nbsp;-&nbsp;" + endRow.ToString() + "&nbsp;" + PageCounterTotalText + "&nbsp;" + TotalRowCount.ToString() + "&nbsp";
    }

    public void PageGroups(GridViewRow PagerRow)
    {
        // Display page groups in pager if GridView.PageCount is greater than the maxVisiblePageNumbers.

        // No data to display.
        if (PagerRow == null) return;

        theGridViewRow = PagerRow;

        HtmlTable pagerOuterTable = (HtmlTable)PagerRow.Cells[0].FindControl("pagerInnerTable");

        if (MaxVisiblePageNumbers == DEFAULT_MAX_VISIBLE)
            MaxVisiblePageNumbers = theGrid.PageCount;

        int maxPageGroups = (int)Math.Ceiling((decimal)theGrid.PageCount / MaxVisiblePageNumbers);
        if (theGrid.PageCount > MaxVisiblePageNumbers)
        {
            int lastCellPosition = pagerOuterTable.Rows[0].Cells.Count - 1;
            decimal pageGroup = Math.Ceiling((decimal)(theGrid.PageIndex + 1) / MaxVisiblePageNumbers);

            DropDownList ddlPageGroups = (DropDownList)pagerOuterTable.Rows[0].Cells[lastCellPosition].FindControl("ddlPageGroups");
            for (int pg = 1; pg <= maxPageGroups; pg++)
            {
                int groupFirstPageNumber = (int)(1 + (maxVisiblePageNumbers * (pg - 1)));
                int groupLastPageNumber = groupFirstPageNumber + (maxVisiblePageNumbers - 1);
                if (theGrid.PageCount < groupLastPageNumber)
                    groupLastPageNumber = theGrid.PageCount;
                string group = String.Format("{0} ... {1}", groupFirstPageNumber.ToString(), groupLastPageNumber.ToString());
                ListItem groupItem = new ListItem(group, groupFirstPageNumber.ToString());
                if (pageGroup == pg)
                    groupItem.Selected = true;
                ddlPageGroups.Items.Add(groupItem);
            }
            // Make the dropdownlist visible.
            pagerOuterTable.Rows[0].Cells[2].Visible = true;
        }
    }

    public void PageGroupChanged(GridViewRow PagerRow)
    {
        // Change the page group.        
        if (PagerRow != null)
        {
            HtmlTable pagerOuterTable = (HtmlTable)PagerRow.Cells[0].FindControl("pagerOuterTable");
            int lastCellPosition = pagerOuterTable.Rows[0].Cells.Count - 1;
            DropDownList ddlPageGroups = (DropDownList)pagerOuterTable.Rows[0].Cells[lastCellPosition].FindControl("ddlPageGroups");
            this.theGrid.PageIndex = Int32.Parse(ddlPageGroups.SelectedValue) - 1;
        }
    }
}
