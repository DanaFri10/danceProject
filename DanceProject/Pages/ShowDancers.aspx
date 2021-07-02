<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDancers.aspx.cs" Inherits="DanceProject.Pages.ShowDancers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
background-color:#fae4e0;
}
        .style1
        {
            width: 37%;
            background-color:rgba(255,255,255,0.5);
            height: 214px;
        }
        .style2
        {
            font-family: Tahoma;
            text-align: center;
        }
                
        .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        width: 150px;
        height: 30px;
  border-radius: 4px;
}

.btn:hover {
  background-color: #555555;
  color: white;
}

.btn1 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
}

.btn1:hover {
  background-color: #555555;
  color: white;
}

#Panel1
{
width:1180px;
    height:220px;
    overflow:auto;

}

#Panel2
{
    position:absolute;
    width:470px;
    height:275px;
    overflow:auto;    
    left:830px;
    top:325px;
}
                
        #tbl
        {
            width:1340px;
        }
    

        
        .style8
        {
            width: 191px;
            text-align: left;
            background-color: rgba(255,255,255,0.5);
            height: 83px;
        }
        
        #GridView1
        {
            background-color: rgba(255,255,255,0.5);
        }
        .style9
        {
            width: 204px;
            text-align: left;
            background-color: rgba(255,255,255,0.5);
            height: 83px;
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
        
                        #ImageButton10
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
<body style="text-align: center; font-family: Tahoma;">
    <form id="form1" runat="server">
    <p>
    <asp:ImageButton ID="ImageButton10" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton10_Click" 
        ToolTip="Log out" CausesValidation="False" />
    </p>
    <div>
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" onmenuitemclick="Menu_MenuItemClick">
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
                <asp:MenuItem Text="Dancers" Value="Dancers"></asp:MenuItem>
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
            Height="70px"  Visible="false" BackColor="White" Width="1364px" 
            onmenuitemclick="Menu_MenuItemClick" >
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
                <asp:MenuItem Text="Dancers" Value="Dancers"></asp:MenuItem>
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
            onmenuitemclick="Menu_MenuItemClick">
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
                <asp:MenuItem Text="Dancers" Value="Dancers"></asp:MenuItem>
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
        <table class="style2" id="tbl">
            <tr>
                <td class="style8">
                    <asp:Label ID="Label18" runat="server" CssClass="style2" 
                        style="font-weight: 700" Text="Filter by age: "></asp:Label>
                    <span class="style2">
                    <br />
                    </span>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Number" Placeholder="From"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" Placeholder="To"></asp:TextBox>
                </td>
                <td class="style8">
                    <asp:Label ID="Label19" runat="server" style="font-weight: 700" 
                        Text="Filter by dance: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <asp:Label ID="Label20" runat="server" 
                        style="font-weight: 700; font-family: Tahoma" Text="Filter by performance: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            </table>
        <br />
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" Text="Filter" class="btn"/>
        <br />
        <br />
        <asp:Label ID="Label21" runat="server" 
            style="font-weight: 700; font-family: Tahoma" Text="Search for dancer name: "></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;<asp:ImageButton ID="Button8" runat="server" 
            onclick="Button8_Click" ImageUrl="/Photos/SearchIcon.png" 
            Height="30px" Width="30px"/>
        <br />
        <br />
        <asp:Label ID="Label24" runat="server" style="font-family: Tahoma"></asp:Label>
        <br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:DataList ID="DataList1" runat="server" CellSpacing="5" RepeatColumns="6" 
            RepeatDirection="Horizontal" onitemcommand="DataList1_ItemCommand" 
            style="font-family: Tahoma" 
    onitemdatabound="DataList1_ItemDataBound" Width="550px">
                <ItemTemplate>
                    <table class="style1" frame="box">
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="142px" 
                                    ImageUrl='<%# Bind("ProfilePicture") %>' Width="174px" />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserFirstName") %>'></asp:Label>
                                &nbsp;<asp:Label ID="Label15" runat="server" Text='<%# Bind("UserLastName") %>'></asp:Label>
                                <br />
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/Photos/ShowIcon.png"
                                    CommandArgument="Bind(&quot;UserId&quot;)" CommandName="ShowDancer" 
                                    Height="20px" Width="20px"  />
                                &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" CommandName="EditUser" ImageUrl="/Photos/PencilIcon.png" Visible="False" Height="20px" Width="20px" />
                                &nbsp;<asp:ImageButton ID="ImageButton6" runat="server" CommandName="Block" 
                                    Visible="False" ImageUrl="/Photos/BlockIcon.png" Height="20px" Width="20px" />
                                <asp:ImageButton ID="ImageButton7" runat="server" CommandName="AddDancer" 
                                    Visible="False" ImageUrl="/Photos/PlusIcon.png" Height="20px" Width="20px"/>
                                <br />
                                <asp:Label ID="Label23" runat="server" Text='<%# Bind("UserId") %>' 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <br />
        
    </div>
    <br />
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        style="font-family: Tahoma" onrowcommand="GridView1_RowCommand" 
        onrowdeleting="GridView1_RowDeleting" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="UserFirstName" 
                HeaderText="Dancer First Name" 
                SortExpression="UserFirstName" />
                <asp:BoundField DataField="UserLastName" 
                HeaderText="Dancer Last Name" SortExpression="UserLastName" />
                <asp:ImageField DataImageUrlField="ProfilePicture" 
                HeaderText="Profile Picture">
                    <ControlStyle Height="50px" Width="50px" />
                    <FooterStyle Height="50px" Width="50px" />
                    <HeaderStyle Height="50px" Width="50px" />
                    <ItemStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:ButtonField ButtonType="Button" CommandName="ShowDancer1" 
                HeaderText="Show" ShowHeader="True" Text="Show" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
                ShowHeader="True" Text="Delete" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:ImageButton ID="ImageButton8" runat="server" onclick="ImageButton8_Click" 
        Visible="False" ImageUrl="/Photos/TickIcon.png" Height="50px" Width="50px"/>
    &nbsp;<asp:ImageButton ID="ImageButton9" runat="server" 
        onclick="ImageButton9_Click" ImageUrl="/Photos/X.png" Visible="False" 
        Height="50px" Width="50px"/>
    <br />
    <asp:Label ID="Label16" runat="server" style="font-family: Tahoma"></asp:Label>
    </form>
</body>
</html>
