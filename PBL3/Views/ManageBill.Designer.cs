
namespace PBL3.Views
{
    partial class ManageBill
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBill));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.btnNote = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnDelete = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnView = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DataBill = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuDropdown1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.entityCommand2 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.detailBill1 = new PBL3.Views.DetailBill();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataBill)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this.bunifuPanel1;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.detailBill1);
            this.bunifuPanel1.Controls.Add(this.btnNote);
            this.bunifuPanel1.Controls.Add(this.btnDelete);
            this.bunifuPanel1.Controls.Add(this.btnView);
            this.bunifuPanel1.Controls.Add(this.DataBill);
            this.bunifuPanel1.Controls.Add(this.bunifuDropdown1);
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 3);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(877, 542);
            this.bunifuPanel1.TabIndex = 2;
            // 
            // btnNote
            // 
            this.btnNote.AllowAnimations = true;
            this.btnNote.AllowMouseEffects = true;
            this.btnNote.AllowToggling = false;
            this.btnNote.AnimationSpeed = 200;
            this.btnNote.AutoGenerateColors = false;
            this.btnNote.AutoRoundBorders = false;
            this.btnNote.AutoSizeLeftIcon = true;
            this.btnNote.AutoSizeRightIcon = true;
            this.btnNote.BackColor = System.Drawing.Color.Transparent;
            this.btnNote.BackColor1 = System.Drawing.Color.LightSalmon;
            this.btnNote.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNote.BackgroundImage")));
            this.btnNote.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnNote.ButtonText = "Note";
            this.btnNote.ButtonTextMarginLeft = 0;
            this.btnNote.ColorContrastOnClick = 45;
            this.btnNote.ColorContrastOnHover = 45;
            this.btnNote.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnNote.CustomizableEdges = borderEdges1;
            this.btnNote.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNote.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNote.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnNote.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnNote.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnNote.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNote.ForeColor = System.Drawing.Color.Black;
            this.btnNote.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNote.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnNote.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnNote.IconMarginLeft = 11;
            this.btnNote.IconPadding = 10;
            this.btnNote.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNote.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnNote.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnNote.IconSize = 25;
            this.btnNote.IdleBorderColor = System.Drawing.SystemColors.Control;
            this.btnNote.IdleBorderRadius = 1;
            this.btnNote.IdleBorderThickness = 1;
            this.btnNote.IdleFillColor = System.Drawing.Color.LightSalmon;
            this.btnNote.IdleIconLeftImage = null;
            this.btnNote.IdleIconRightImage = null;
            this.btnNote.IndicateFocus = false;
            this.btnNote.Location = new System.Drawing.Point(757, 443);
            this.btnNote.Name = "btnNote";
            this.btnNote.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnNote.OnDisabledState.BorderRadius = 1;
            this.btnNote.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnNote.OnDisabledState.BorderThickness = 1;
            this.btnNote.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnNote.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnNote.OnDisabledState.IconLeftImage = null;
            this.btnNote.OnDisabledState.IconRightImage = null;
            this.btnNote.onHoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnNote.onHoverState.BorderRadius = 1;
            this.btnNote.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnNote.onHoverState.BorderThickness = 1;
            this.btnNote.onHoverState.FillColor = System.Drawing.Color.Firebrick;
            this.btnNote.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnNote.onHoverState.IconLeftImage = null;
            this.btnNote.onHoverState.IconRightImage = null;
            this.btnNote.OnIdleState.BorderColor = System.Drawing.SystemColors.Control;
            this.btnNote.OnIdleState.BorderRadius = 1;
            this.btnNote.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnNote.OnIdleState.BorderThickness = 1;
            this.btnNote.OnIdleState.FillColor = System.Drawing.Color.LightSalmon;
            this.btnNote.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnNote.OnIdleState.IconLeftImage = null;
            this.btnNote.OnIdleState.IconRightImage = null;
            this.btnNote.OnPressedState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnNote.OnPressedState.BorderRadius = 1;
            this.btnNote.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnNote.OnPressedState.BorderThickness = 1;
            this.btnNote.OnPressedState.FillColor = System.Drawing.Color.Firebrick;
            this.btnNote.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnNote.OnPressedState.IconLeftImage = null;
            this.btnNote.OnPressedState.IconRightImage = null;
            this.btnNote.Size = new System.Drawing.Size(106, 54);
            this.btnNote.TabIndex = 5;
            this.btnNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNote.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnNote.TextMarginLeft = 0;
            this.btnNote.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnNote.UseDefaultRadiusAndThickness = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AllowAnimations = true;
            this.btnDelete.AllowMouseEffects = true;
            this.btnDelete.AllowToggling = false;
            this.btnDelete.AnimationSpeed = 200;
            this.btnDelete.AutoGenerateColors = false;
            this.btnDelete.AutoRoundBorders = false;
            this.btnDelete.AutoSizeLeftIcon = true;
            this.btnDelete.AutoSizeRightIcon = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackColor1 = System.Drawing.Color.LightSalmon;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.ButtonTextMarginLeft = 0;
            this.btnDelete.ColorContrastOnClick = 45;
            this.btnDelete.ColorContrastOnHover = 45;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnDelete.CustomizableEdges = borderEdges2;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDelete.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDelete.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDelete.IconMarginLeft = 11;
            this.btnDelete.IconPadding = 10;
            this.btnDelete.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDelete.IconSize = 25;
            this.btnDelete.IdleBorderColor = System.Drawing.SystemColors.Control;
            this.btnDelete.IdleBorderRadius = 1;
            this.btnDelete.IdleBorderThickness = 1;
            this.btnDelete.IdleFillColor = System.Drawing.Color.LightSalmon;
            this.btnDelete.IdleIconLeftImage = null;
            this.btnDelete.IdleIconRightImage = null;
            this.btnDelete.IndicateFocus = false;
            this.btnDelete.Location = new System.Drawing.Point(757, 383);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDelete.OnDisabledState.BorderRadius = 1;
            this.btnDelete.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDelete.OnDisabledState.BorderThickness = 1;
            this.btnDelete.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDelete.OnDisabledState.IconLeftImage = null;
            this.btnDelete.OnDisabledState.IconRightImage = null;
            this.btnDelete.onHoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnDelete.onHoverState.BorderRadius = 1;
            this.btnDelete.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDelete.onHoverState.BorderThickness = 1;
            this.btnDelete.onHoverState.FillColor = System.Drawing.Color.Firebrick;
            this.btnDelete.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.onHoverState.IconLeftImage = null;
            this.btnDelete.onHoverState.IconRightImage = null;
            this.btnDelete.OnIdleState.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDelete.OnIdleState.BorderRadius = 1;
            this.btnDelete.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDelete.OnIdleState.BorderThickness = 1;
            this.btnDelete.OnIdleState.FillColor = System.Drawing.Color.LightSalmon;
            this.btnDelete.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.OnIdleState.IconLeftImage = null;
            this.btnDelete.OnIdleState.IconRightImage = null;
            this.btnDelete.OnPressedState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnDelete.OnPressedState.BorderRadius = 1;
            this.btnDelete.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDelete.OnPressedState.BorderThickness = 1;
            this.btnDelete.OnPressedState.FillColor = System.Drawing.Color.Firebrick;
            this.btnDelete.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.OnPressedState.IconLeftImage = null;
            this.btnDelete.OnPressedState.IconRightImage = null;
            this.btnDelete.Size = new System.Drawing.Size(106, 54);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelete.TextMarginLeft = 0;
            this.btnDelete.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDelete.UseDefaultRadiusAndThickness = true;
            // 
            // btnView
            // 
            this.btnView.AllowAnimations = true;
            this.btnView.AllowMouseEffects = true;
            this.btnView.AllowToggling = false;
            this.btnView.AnimationSpeed = 200;
            this.btnView.AutoGenerateColors = false;
            this.btnView.AutoRoundBorders = false;
            this.btnView.AutoSizeLeftIcon = true;
            this.btnView.AutoSizeRightIcon = true;
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.BackColor1 = System.Drawing.Color.LightSalmon;
            this.btnView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnView.BackgroundImage")));
            this.btnView.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnView.ButtonText = "ViewDetail";
            this.btnView.ButtonTextMarginLeft = 0;
            this.btnView.ColorContrastOnClick = 45;
            this.btnView.ColorContrastOnHover = 45;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnView.CustomizableEdges = borderEdges3;
            this.btnView.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnView.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnView.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnView.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnView.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnView.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnView.IconMarginLeft = 11;
            this.btnView.IconPadding = 10;
            this.btnView.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnView.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnView.IconSize = 25;
            this.btnView.IdleBorderColor = System.Drawing.SystemColors.Control;
            this.btnView.IdleBorderRadius = 1;
            this.btnView.IdleBorderThickness = 1;
            this.btnView.IdleFillColor = System.Drawing.Color.LightSalmon;
            this.btnView.IdleIconLeftImage = null;
            this.btnView.IdleIconRightImage = null;
            this.btnView.IndicateFocus = false;
            this.btnView.Location = new System.Drawing.Point(757, 323);
            this.btnView.Name = "btnView";
            this.btnView.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnView.OnDisabledState.BorderRadius = 1;
            this.btnView.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnView.OnDisabledState.BorderThickness = 1;
            this.btnView.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnView.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnView.OnDisabledState.IconLeftImage = null;
            this.btnView.OnDisabledState.IconRightImage = null;
            this.btnView.onHoverState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnView.onHoverState.BorderRadius = 1;
            this.btnView.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnView.onHoverState.BorderThickness = 1;
            this.btnView.onHoverState.FillColor = System.Drawing.Color.Firebrick;
            this.btnView.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnView.onHoverState.IconLeftImage = null;
            this.btnView.onHoverState.IconRightImage = null;
            this.btnView.OnIdleState.BorderColor = System.Drawing.SystemColors.Control;
            this.btnView.OnIdleState.BorderRadius = 1;
            this.btnView.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnView.OnIdleState.BorderThickness = 1;
            this.btnView.OnIdleState.FillColor = System.Drawing.Color.LightSalmon;
            this.btnView.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.btnView.OnIdleState.IconLeftImage = null;
            this.btnView.OnIdleState.IconRightImage = null;
            this.btnView.OnPressedState.BorderColor = System.Drawing.Color.Firebrick;
            this.btnView.OnPressedState.BorderRadius = 1;
            this.btnView.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnView.OnPressedState.BorderThickness = 1;
            this.btnView.OnPressedState.FillColor = System.Drawing.Color.Firebrick;
            this.btnView.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnView.OnPressedState.IconLeftImage = null;
            this.btnView.OnPressedState.IconRightImage = null;
            this.btnView.Size = new System.Drawing.Size(106, 54);
            this.btnView.TabIndex = 2;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnView.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnView.TextMarginLeft = 0;
            this.btnView.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnView.UseDefaultRadiusAndThickness = true;
            // 
            // DataBill
            // 
            this.DataBill.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(196)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DataBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataBill.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.DataBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataBill.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataBill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataBill.ColumnHeadersHeight = 40;
            this.DataBill.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(196)))), ((int)(((byte)(206)))));
            this.DataBill.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataBill.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataBill.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(114)))), ((int)(((byte)(138)))));
            this.DataBill.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataBill.CurrentTheme.BackColor = System.Drawing.Color.Crimson;
            this.DataBill.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.DataBill.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Crimson;
            this.DataBill.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataBill.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataBill.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(16)))), ((int)(((byte)(48)))));
            this.DataBill.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataBill.CurrentTheme.Name = null;
            this.DataBill.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(208)))), ((int)(((byte)(216)))));
            this.DataBill.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataBill.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataBill.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(114)))), ((int)(((byte)(138)))));
            this.DataBill.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(208)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(114)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataBill.EnableHeadersVisualStyles = false;
            this.DataBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(184)))), ((int)(((byte)(196)))));
            this.DataBill.HeaderBackColor = System.Drawing.Color.Crimson;
            this.DataBill.HeaderBgColor = System.Drawing.Color.Empty;
            this.DataBill.HeaderForeColor = System.Drawing.Color.White;
            this.DataBill.Location = new System.Drawing.Point(41, 131);
            this.DataBill.Name = "DataBill";
            this.DataBill.RowHeadersVisible = false;
            this.DataBill.RowTemplate.Height = 40;
            this.DataBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataBill.Size = new System.Drawing.Size(675, 366);
            this.DataBill.TabIndex = 0;
            this.DataBill.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Crimson;
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.bunifuDropdown1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDropdown1.BorderRadius = 1;
            this.bunifuDropdown1.Color = System.Drawing.Color.Silver;
            this.bunifuDropdown1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuDropdown1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bunifuDropdown1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.bunifuDropdown1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.FillDropDown = true;
            this.bunifuDropdown1.FillIndicator = false;
            this.bunifuDropdown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.FormattingEnabled = true;
            this.bunifuDropdown1.Icon = null;
            this.bunifuDropdown1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.IndicatorColor = System.Drawing.Color.Gray;
            this.bunifuDropdown1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown1.ItemBackColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.ItemHeight = 26;
            this.bunifuDropdown1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemTopMargin = 3;
            this.bunifuDropdown1.Location = new System.Drawing.Point(41, 59);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.Size = new System.Drawing.Size(260, 32);
            this.bunifuDropdown1.TabIndex = 1;
            this.bunifuDropdown1.Text = null;
            this.bunifuDropdown1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown1.TextLeftMargin = 5;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // entityCommand2
            // 
            this.entityCommand2.CommandTimeout = 0;
            this.entityCommand2.CommandTree = null;
            this.entityCommand2.Connection = null;
            this.entityCommand2.EnablePlanCaching = true;
            this.entityCommand2.Transaction = null;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 35;
            this.bunifuElipse2.TargetControl = this;
            // 
            // detailBill1
            // 
            this.detailBill1.Location = new System.Drawing.Point(-3, -3);
            this.detailBill1.Name = "detailBill1";
            this.detailBill1.Size = new System.Drawing.Size(877, 542);
            this.detailBill1.TabIndex = 6;
            this.detailBill1.Visible = false;
            // 
            // ManageBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ManageBill";
            this.Size = new System.Drawing.Size(877, 542);
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView DataBill;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand2;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnNote;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnDelete;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnView;
        private DetailBill detailBill1;
    }
}
