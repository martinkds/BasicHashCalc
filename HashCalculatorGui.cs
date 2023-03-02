using System;
using System.Windows.Forms;
using System.Drawing;

public class HashCalculatorGui : Form
{
	RadioButton[] rbOptions = null;
    TextBox input = new TextBox();
    TextBox output = new TextBox();
    Button btnOk = null;
    
    public HashCalculatorGui()
    {
		string[] hashLength = {"SHA1","SHA512","SHA384","SHA256","MD5"};
        this.Text = "C# Basic Hash Calculator";
        this.Font = new Font("Arial",9.75F);
        this.Controls.Add(new Label()
        {
            Text = "Plain Text: ",
            Location = new Point(10,10),
            AutoSize = true
        });
        input = new TextBox()
        {
           Location = new Point(10,30),
           Size = new Size(260,90),
           Multiline = true,
           ScrollBars = ScrollBars.Horizontal
        };
        this.Controls.Add(input);
        GroupBox optionsGroup = new GroupBox(){
            Text = "Choose the algorithm",
            Location = new Point(10,120),
            Size = new Size(140,126)
        };
        rbOptions = new RadioButton[hashLength.Length];
        for(var i = 0; i < hashLength.Length;i++)
        {
            var ypos = 20;
            rbOptions[i] = new RadioButton();
            rbOptions[i].Text = hashLength[i];
            rbOptions[i].AutoSize = true;
            rbOptions[i].Location = new Point(10,(ypos * (i + 1)));
            rbOptions[i].Checked = (i == 0);
            optionsGroup.Controls.Add(rbOptions[i]);
        }
        this.Controls.Add(optionsGroup);
        btnOk = new Button()
        {
			Text = "Create Hash",
			Location = new Point(180,150),
            AutoSize = true
		};
		btnOk.Click += new System.EventHandler(this.btnOk_Click);
		this.Controls.Add(btnOk);
        output = new TextBox()
        {
           Location = new Point(10,250),
           Size = new Size(260,100),
           Multiline = true,
           ScrollBars = ScrollBars.Horizontal,
           ReadOnly = true
        };
        this.Controls.Add(output);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ClientSize = new Size(280, 380);
        this.BackColor = Color.White;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
	}
	
	private void btnOk_Click(object sender, EventArgs e)
	{
		string message = input.Text;
		string algorithm = rbOptions[0].Text;
		output.Text = "";
		foreach(var item in rbOptions)
		{
			if(item.Checked)
				algorithm = item.Text;
		}
		MessageDigest digest = new MessageDigest(message,algorithm);
        byte[] hashCode = digest.Digest();
        foreach(var item in hashCode)
        {
			output.Text += String.Format("{0:X2} ", item);
		}
	}
}
