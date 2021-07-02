<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowChoreographers.aspx.cs" Inherits="DanceProject.Pages.ShowChoreographers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        
        body  {
background-color:#fae4e0;
            font-family: Tahoma;
        }
       
        .style1
        {
            width: 100%;
            text-align: center;
            font-family: Tahoma;
        }
        .style2
        {
            height: 30px;
        }
        #ImageButton1
{
    position:absolute;
    top:14px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: -23px;
            z-index:5;
        }
        
        
        #Menu1
        {
            position:absolute;
            top:14px;
            left:14px;
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
            left:14px;
        }
        
        
        #ImageButton2
        {
            position:absolute;
            top:24px;
            left:1102px;
            right: 238px;
            height: 40px;
            width: 40px;
            z-index:5;
        }
        
        #ImageButton3
        {
            position:absolute;
            top:24px;
            left:1156px;
            height: 42px;
            width: 43px;
            z-index:5;
        }
        
        #Panel1
{
width:1300px;
    height:530px;
    overflow:auto;

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
<body>
    <form id="form1" runat="server">
    <p>
    <asp:ImageButton ID="ImageButton6" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton6_Click" 
        ToolTip="Log out" CausesValidation="False" />
    </p>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
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

        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
        onclick="ImageButton3_Click" CausesValidation="False" />

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
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
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
            onclick="ImageButton1_Click" CausesValidation="False"/>
        <asp:ImageButton ID="ImageButton2" runat="server" 
        ImageUrl="/Photos/NotificationIcon.png" ToolTip="Notifications" 
        onclick="ImageButton2_Click" CausesValidation="False" />
        <br />
    <div>
    
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <asp:DataList ID="DataList1" runat="server" CellSpacing="5" RepeatColumns="7" 
            RepeatDirection="Horizontal" onitemcommand="DataList1_ItemCommand" 
            onitemdatabound="DataList1_ItemDataBound" Width="600px">
            <ItemTemplate>
                <table class="style1" frame="box">
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text='<%# Bind("UserId") %>' 
                                Visible="False"></asp:Label>
                            <br />
                            <asp:Image ID="Image1" runat="server" Height="142px" 
                                ImageUrl='<%# Bind("ProfilePicture") %>' Width="174px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Bind("UserFirstName") %>'></asp:Label>
                            <asp:Label ID="Label15" runat="server" Text='<%# Bind("UserLastName") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/Photos/ShowIcon.png"
                                CommandArgument="Bind(&quot;UserId&quot;)" CommandName="ShowChoreographer" 
                                Height="20px" Width="20px" />
                            <asp:ImageButton ID="ImageButton7" runat="server" Height="20px" Width="20px" 
                                ImageUrl="/Photos/PencilIcon.png" CommandName="Edit" Visible="False" />
                            &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" CommandName="Block" 
                                Text="Block" ImageUrl="/Photos/BlockIcon.png"
                                Visible="False" Height="20px" Width="20px" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    </form>
</body>
</html>
