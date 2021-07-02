<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePersonalData.aspx.cs" Inherits="DanceProject.Pages.UpdatePersonalData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
body {
background-color:#fae4e0;
}
  #ImageButton1
{
    position:absolute;
    top:14px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: -23px;
        }
        
        
        #Menu1
        {
            position:absolute;
            top:14px;
            left:0px;
        }
        
                #Menu2
        {
            position:absolute;
            top:14px;
            left:0px;
        }
          
                
        #Menu3
        {
            position:absolute;
            top:14px;
            left:0px;
        }
        
        
        #ImageButton2
        {
            position:absolute;
            top:24px;
            left:1102px;
            right: 229px;
            z-index:5;
        }
        
        #ImageButton3
        {
            position:absolute;
            top:24px;
            left:1156px;
            height: 42px;
            width: 43px;
        }      
        .style1
        {
            text-align: center;
        }
        
        #Panel1
        {
            background-color:rgba(255,255,255,0.5);
            width: 990px;
            height:450px;
            position:absolute;
            top:150px;
            left:300px;
            border-radius:4px;
            border-width:2px;
            border-color:#555555;
            border-style:solid;
        }
        #Image1
        {
            position:absolute;
            top:150px;
            Height:157px; 
            Width:274px;
        }
        #Button1
{
    width:150px;
    background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
}
#Button1:hover {
  background-color: #555555;
  color: white;
} 

#Button2
{
    width:150px;
    background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
}
#Button2:hover {
  background-color: #555555;
  color: white;
}   

        #ImageButton4
        {
            position:absolute;
            top:550px;
            left:60px;
        }
                #ImageButton5
        {
            position:absolute;
            top:550px;
            left:120px;
        }
        
                        #ImageButton6
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
        }
                #Hi
        {
            position:absolute;
            top:70px;
            left:1093px;
            z-index:5;
            text-align: center;
            width: 170px;
        }

    </style>
</head>
<body style="text-align: left; font-family: Tahoma">
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Admin" Value="Admin">
                    <asp:MenuItem NavigateUrl="BlockedUsers.aspx" 
                        Text="Show blocked users and new activities" 
                        Value="Show blocked users and new activities"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Catagories.aspx" Text="Show categories" 
                        Value="Show categories"></asp:MenuItem>
                        </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton2_Click" CausesValidation="False" />

            <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

<asp:Menu ID="Menu3" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" 
            >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton1_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" />
        <br />
        <br />
        <br />
        <br />
    <asp:ImageButton ID="ImageButton6" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton6_Click" 
        ToolTip="Log out" CausesValidation="False" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:TextBox ID="UserFirstName" runat="server" Font-Size="X-Large" 
            Width="274px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="UserFirstName" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="UserLastName" runat="server" Font-Size="X-Large" Width="274px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="UserLastName" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <div class="style1">
                <br />
                <asp:Label ID="Label1" runat="server" 
                    style="font-weight: 700" Text="User type:"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Choreographer</asp:ListItem>
                    <asp:ListItem>Dancer</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Id: "></asp:Label>
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                    Text="Password: "></asp:Label>
                <asp:TextBox ID="UserPassword" runat="server"></asp:TextBox>
                &nbsp;<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="UserPassword" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                    runat="server" ControlToValidate="UserPassword" 
                    ErrorMessage="Your password must contain 5-10 characters" 
                    ValidationExpression="\w{5,10}"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
                    Text="Birth date: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                &nbsp;<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="Label7" runat="server" style="font-weight: 700" 
                    Text="Phone number: "></asp:Label>
                <asp:TextBox ID="UserPhoneNumber" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="UserPhoneNumber" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
                    runat="server" ControlToValidate="UserPhoneNumber" 
                    ErrorMessage="Your phone number must contain 10 digits" 
                    ValidationExpression="\d{10}" ViewStateMode="Enabled"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="Label12" runat="server" style="font-weight: 700" Text="Email:"></asp:Label>
                &nbsp;<asp:TextBox ID="UserEmail" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="UserEmail" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
                    runat="server" ControlToValidate="UserEmail" ErrorMessage="Incorrect form" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            </div>
        </asp:Panel>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton4" runat="server" onclick="ImageButton4_Click" 
            ImageUrl="/Photos/TickIcon.png" Height="50px" Width="50px"/>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton5" runat="server" onclick="ImageButton5_Click" 
            ImageUrl="/Photos/X.png" Height="50px" Width="50px" />
        <br />
    </div>
    </form>
</body>
</html>
