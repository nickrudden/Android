using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestRecipeApp.Utilites
{
    public class CheckBoxGroup : GridLayout
    {
        List<CheckBox> checkboxes;
        Context con;
        public CheckBoxGroup(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            con = context;
            checkboxes = new List<CheckBox>();
        }

        public void putCheck(CheckBox check)
        {
            if (check != null)
            {
                checkboxes.Add(check);
                Invalidate();
                RequestLayout();
            }
        }

        public List<CheckBox> getCheckboxesChecked()
        {
            List<CheckBox> ch = new List<CheckBox>();
            foreach (CheckBox c in checkboxes)
            {
                if (c.Checked)
                    ch.Add(c);
            }

            return ch;
        }

        public List<Object> getCheckedIds()
        {
            List<Object> ch = new List<Object>();
            foreach (CheckBox c in checkboxes)
            {
                if (c.Checked)
                    ch.Add(c.Tag);
            }

            return ch;
        }

        
        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            foreach (CheckBox item in checkboxes)
            {
               
               
            }

            Invalidate();
            RequestLayout();
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
        }

        public void addDietCheckBoxes()
        {
            CheckBox checkDairy = new CheckBox(con);
            checkDairy.Tag = "dairy";
            checkDairy.Text = "Dairy";
            putCheck(checkDairy);

            CheckBox checkEgg = new CheckBox(con);
            checkDairy.Tag = "egg";
            checkDairy.Text = "Egg";
            putCheck(checkDairy);

            CheckBox checkGluten = new CheckBox(con);
            checkDairy.Tag = "gluten";
            checkDairy.Text = "Gluten";
            putCheck(checkDairy);
        }
    }
}