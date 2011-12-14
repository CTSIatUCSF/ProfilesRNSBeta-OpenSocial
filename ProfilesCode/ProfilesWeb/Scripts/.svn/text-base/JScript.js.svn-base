/*  
 
Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
National Center for Research Resources and Harvard University.


Code licensed under a BSD License. 
For details, see: LICENSE.txt 
  
*/
function Toggle(item)
{
    obj = $get(item);
    if (obj != null)
    {
        visible = (obj.style.display != "none")
        if (visible)
        {
            obj.style.display="none";
        }
        else
        {
            obj.style.display="block";
        }
    }
}

function Backward(oSpyID)
{
   // The hidden post-back spy or counter field
   var spy = null;
   // Total number of post-backs
   var refreshes = new Number(0);
   // Allows the actual previous page to be selected
   var offset = new Number(1);

   spy = document.getElementById(oSpyID);

   refreshes = new Number(spy.value) + offset;
               
   history.go(-refreshes);
   // Redirects to the actual previous page
}

function Forward()
{
   history.forward(1);
   // Redirects if the next page exists,
   // including the post-back versions.
}
