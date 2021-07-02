<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDates.aspx.cs" Inherits="DanceProject.Pages.SelectDates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body  {
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
            top:27px;
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
        #Calendar1
        {
            background-color:rgba(255,255,255,0.5);
            position:absolute;
            left:190px;
            top: 202px;
        }
        #Image1
        {
            position:absolute;
            left:729px;
            top: 202px;
        }
        .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
  width:120px;
            text-align: center;
        }

.btn:hover {
  background-color: #555555;
  color: white;
}
                #ImageButton6
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            z-index:5;
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
<body style="font-family: Tahoma; text-align: center;">
    <form id="form1" runat="server">
     <p>
    <asp:ImageButton ID="ImageButton6" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton6_Click" 
        ToolTip="Log out" CausesValidation="False" />
     </p>
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
            onclick="ImageButton1_Click" ToolTip="Home page" 
         CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
        onclick="ImageButton3_Click" CausesValidation="False" />
    <br />
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Font-Size="XX-Large" 
        style="font-weight: 700" Text="Add performance dates:"></asp:Label>
    <br />
    <asp:Label ID="Label10" runat="server" Font-Size="Large" 
        style="font-weight: 700" Text="Performance name:"></asp:Label>
&nbsp;<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <asp:Calendar ID="Calendar1" runat="server" ondayrender="Calendar1_DayRender" 
        Width="500px" Height="200px" ></asp:Calendar>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label7" runat="server"></asp:Label>
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="/Photos/ColorChart.png" 
        style="text-align: right; margin-bottom: 0px" Height="200px" />
    <br />
    <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
        Text="Performance Place:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox2" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
        Text="Select Hours:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server" TextMode="Time"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox3" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:ImageButton ID="ImageButton4" runat="server" onclick="ImageButton4_Click" 
         ImageUrl="/Photos/TickIcon.png" Height="50px" Width="50px" />
    &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="/Photos/X.png"
        CausesValidation="False" onclick="ImageButton5_Click" Height="50px" 
         Width="50px"/>
    <br />
    <br />
    <asp:Label ID="Label8" runat="server"></asp:Label>
    <div>
    
    </div>
    </form>
</body>
</html>
