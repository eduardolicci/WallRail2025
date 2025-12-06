using System;
using System.Windows.Controls;

namespace WallRail2025
{
    public partial class MainForm : Tekla.Structures.Dialog.PluginFormBase
    {
        public MainForm()
        {
            InitializeComponent();
            if (RailGeometryType.Text == "1")
            {
                Straight.Checked = true;

            }
            else if (RailGeometryType.Text == "0")
            {

                Leveled.Checked = true;
            }
            



        }

        private void OkApplyModifyGetOnOffCancel_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void OkApplyModifyGetOnOffCancel_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void OkApplyModifyGetOnOffCancel_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void OkApplyModifyGetOnOffCancel_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void OkApplyModifyGetOnOffCancel_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void OkApplyModifyGetOnOffCancel_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ParametersTabPage_Click(object sender, EventArgs e)
        {

        }

        private void Leveled_CheckedChanged(object sender, EventArgs e)
        {
            if (Leveled.Checked)
            {
                SetAttributeValue(RailGeometryType, "0");
                
            }
        }

        private void Straight_CheckedChanged(object sender, EventArgs e)
        {
            if (Straight.Checked)
            {
                SetAttributeValue(RailGeometryType, "1");
                
                
                
            }
        }

        private void ProfileCatalog_SelectClicked(object sender, EventArgs e)
        {
            ProfileCatalog.SelectedProfile = SelectedProfileBox.Text;
        }

        private void ProfileCatalog_SelectionDone(object sender, EventArgs e)
        {
            SetAttributeValue(SelectedProfileBox, ProfileCatalog.SelectedProfile);
        }

        private void MaterialCatalog_SelectClicked(object sender, EventArgs e)
        {
            
            MaterialCatalog.SelectedMaterial = SelectedMaterialBox.Text;
  
        }

        private void MaterialCatalog_SelectionDone(object sender, EventArgs e)
        {
            
            SetAttributeValue(SelectedMaterialBox, MaterialCatalog.SelectedMaterial);
        }

        private void RailGeometryType_TextChanged(object sender, EventArgs e)
        {
            // If the hidden box says "1", check Straight. Otherwise, check Leveled.
            if (RailGeometryType.Text == "1")
            {
                Straight.Checked = true;

            }
            else
            {
                Leveled.Checked = true;
            }
        }
    }
}