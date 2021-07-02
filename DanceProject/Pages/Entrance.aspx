<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrance.aspx.cs" Inherits="DanceProject.Pages.Entrance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body  {
  background-image: url('/Photos/Entrence.png');
background-position: center center;
background-size: cover;
background-repeat: no-repeat;
background-attachment: fixed;
webkit-background-size: cover;
-moz-background-size: cover;
-o-background-size: cover;
            font-family: Tahoma;
        }

#Button1
{
    position: absolute;
  left: 200px;
  top: 425px;
            font-family: "Bahnschrift SemiBold";
        }


#Button2
{
        position: absolute;
  left: 950px;
  top: 425px;
            font-family: "Bahnschrift SemiBold";
        }
.btn {
  background-color: #fadadd;
  color: #555555;
  border: 3px solid #555555;
        width: 210px;
        height: 210px;
  border-radius: 4px;
  font-size:40px;
}

.btn:hover {
  background-color: #555555;
  color: #fadadd;
}

#Panel1
{
    position:absolute;
    top:420px;
    left:100px;
    background-color: rgba(255,255,255,0.5);
    font-family: 'Bahnschrift SemiLight';
    border: 1px solid #555555;
    border-radius: 4px;
    height:210px;
    overflow:auto;
    width:400px;
}
#Panel2
{
    position:absolute;
    top:210px;
    left:850px;
    background-color: rgba(255,255,255,0.5);
    font-family: 'Bahnschrift SemiLight';
    border: 1px solid #555555;
    border-radius: 4px;
    height:420px;
    overflow:auto;
    width:400px;
}
        .style1
        {
            text-align: center;
        }
        
        .btn1 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        border-radius: 4px;
}

.btn1:hover {
  background-color: #555555;
  color: white;
}

.val
{
Display:Dynamic;
}

#UserId
{
    position:absolute;
    left:125px;
}

#UserPassword
{
    position:absolute;
    left:125px;
}

.TextBoxex
{
        position:absolute;
    left:125px;
    width:150px;
}
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="LOGIN" class="btn" 
            onclick="Button1_Click" CausesValidation="False"/>
        <asp:Button ID="Button2" runat="server" Text="REGISTER" class="btn" 
            onclick="Button2_Click" CausesValidation="False"/>
    
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="style1">
                <br />
                <asp:TextBox ID="UserId" runat="server" Placeholder="Enter your Id" 
                    Width="150px"></asp:TextBox>
                &nbsp;<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="UserId" Display="Dynamic" 
                    ErrorMessage="You must enter your Id"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="UserId" Display="Dynamic" 
                    ErrorMessage="Make sure your Id is 9 digits" style="text-align: center" 
                    ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br /> 
                <asp:TextBox ID="UserPassword" runat="server" Placeholder="Enter your password" 
                    TextMode="Password" Width="150px"></asp:TextBox>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton3" runat="server" onclick="Button3_Click" 
                    style="font-family: 'Bahnschrift SemiLight'" 
                    ImageUrl="/Photos/TickIcon.png" Width="30px" />
&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" ImageUrl="/Photos/X.png"
                    onclick="Button5_Click" Text="Cancel" Width="30px" />
                <asp:ImageButton ID="Button4" runat="server" 
                    ImageUrl="/Photos/ForgotPasswordIcon.png" onclick="Button4_Click" 
                    Width="30px" />
                <br />
                <br />
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="style1">
                <br />
                <asp:Label ID="Label11" runat="server" Text="Enter your user type:"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                    <asp:ListItem>Choreographer</asp:ListItem>
                    <asp:ListItem>Dancer</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" PlaceHolder="Enter your Id" 
                    class="TextBoxes" Width="150px"></asp:TextBox>
                &nbsp;<br /> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                    runat="server" ControlToValidate="TextBox1" Display="Dynamic" 
                    ErrorMessage="Your Id must contain 9 digits" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" PlaceHolder="Enter your password" 
                    class="TextBoxes" Width="150px"></asp:TextBox>
                &nbsp;<br /> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                    runat="server" ControlToValidate="TextBox2" 
                    ErrorMessage="Your password must contain 5-10 characters" 
                    ValidationExpression="\w{5,10}" Display="Dynamic"></asp:RegularExpressionValidator>
                <br />
                <asp:TextBox ID="UserFirstName" runat="server" PlaceHolder="First name" 
                    class="TextBoxes" Width="150px"></asp:TextBox>
                &nbsp;-&nbsp;<asp:TextBox ID="UserLastName" runat="server" PlaceHolder="Last name" 
                    class="TextBoxes" Width="150px"></asp:TextBox>
                &nbsp;<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="UserFirstName" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="UserLastName" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" 
                    PlaceHolder="Birth date" class="TextBoxes" Width="150px"></asp:TextBox>
                <br />
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="UserPhoneNumber" runat="server" PlaceHolder="Phone number" 
                    class="TextBoxes" Width="150px"></asp:TextBox>
                &nbsp;<br /> <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="UserPhoneNumber" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                    runat="server" ControlToValidate="UserPhoneNumber" Display="Dynamic" 
                    ErrorMessage="Your phone number must contain 10 digits" 
                    ValidationExpression="\d{10}" ViewStateMode="Enabled"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Upload your profile picture:"></asp:Label>
                &nbsp;<br />&nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" 
                    class="TextBoxes" PlaceHolder="Profile picture" Width="150px" />
                <br />
                <br />
                &nbsp;<asp:TextBox ID="UserEmail" runat="server" class="TextBoxes" PlaceHolder="Email" 
                    Width="150px"></asp:TextBox>
                <br />
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="UserEmail" Display="Dynamic" 
                    ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                    runat="server" ControlToValidate="UserEmail" Display="Dynamic" 
                    ErrorMessage="Incorrect form" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:ImageButton ID="ImageButton6" runat="server" 
                    ImageUrl="/Photos/TickIcon.png" onclick="Button6_Click" Width="30px" />
                &nbsp;<asp:ImageButton ID="ImageButton7" runat="server"  onclick="Button7_Click" 
                    ImageUrl="/Photos/X.png" Width="30px" CausesValidation="False" />
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
