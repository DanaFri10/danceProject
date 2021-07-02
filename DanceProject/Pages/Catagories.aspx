<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catagories.aspx.cs" Inherits="DanceProject.Pages.Catrgories" %>

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
        
        #GridView1
        {background-color:rgba(255,255,255,0.5);
        }
        
        #Button1
{        width: 130px;
        height: 30px;
  background-color: white;
  color: black;
  border: 1px solid #555555;
  border-radius: 4px;
}

#Button1:hover {
  background-color: #555555;
  color: white;
}
                #ImageButton5
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
<body style="font-family: Tahoma">
    <form id="form1" runat="server">
    <p>
    <asp:ImageButton ID="ImageButton5" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton5_Click" 
        ToolTip="Log out" CausesValidation="False" />
    </p>
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
        <asp:Label ID="Label1" runat="server" Text="Choose a category: " 
            style="font-weight: 700"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            style="font-family: Tahoma">
            <asp:ListItem>Dance style</asp:ListItem>
            <asp:ListItem>Dance types</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            <asp:ListItem>Valid Categories</asp:ListItem>
            <asp:ListItem>Invalid Categories</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
            style="text-align: center">
            <Columns>
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" 
                    SortExpression="CategoryName" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" 
                    HeaderText="Delete Category" ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter a new category: " 
            style="font-weight: 700"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;<asp:ImageButton ID="ImageButton4" runat="server" 
            onclick="ImageButton4_Click" ImageUrl="/Photos/TickIcon.png" Width="30px"/>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
        &nbsp;<br />
    </div>
    </form>
</body>
</html>
