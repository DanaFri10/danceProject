<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="DanceProject.Pages.HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body  {
  background-image: url("/Photos/HomePage.png");
}
        .style1
        {
            width: 100%;
            text-align: center;
        }
        .style2
        {
            width: 100%;
            text-align: center;
        }
        
        .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
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
        width: 130px;
        height: 30px;
  border-radius: 4px;
}
.btn1:hover {
  background-color: #555555;
  color: white;
}

#lists
{
    background-color:rgba(255,255,255,0.5);
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
        
#ImageButton1
{
    position:absolute;
    top:17px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: 71px;
        }
        
        
        
        
        
        #Label8
        {
            border-radius: 50%;
            position:absolute;
            top:16px;
            left:1123px;
            text-align: center;
        }
                
                #ImageButton3
        {
            position:absolute;
            top:29px;
            left:1156px;
            height: 42px;
            width: 43px;
        }
        #ImageButton4
        {
            position:absolute;
            top:30px;
            left:1099px;
            right: 231px;
            height: 36px;
            z-index:2;
        }
        
#ImageButton5
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            z-index:1;
            right: 288px;
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
        &nbsp;</p>
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

        <asp:ImageButton ID="ImageButton4" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" onclick="ImageButton4_Click" 
            ToolTip="Notifications" CausesValidation="False"/>

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
            Height="70px"  Visible="false" BackColor="White" Width="1364px" >
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
        <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
            Text="Your upcoming performances:" Font-Size="X-Large"></asp:Label>
        &nbsp;<asp:Label ID="Label9" runat="server" Text=""></asp:Label>
        <br />
        <asp:DataList ID="DataList1" runat="server" CellSpacing="5" class="lists" 
            onitemcommand="DataList1_ItemCommand" RepeatColumns="5" 
            RepeatDirection="Horizontal" onitemdatabound="DataList1_ItemDataBound" 
            CellPadding="5">
            <ItemStyle Width="250px" BorderColor="Black" />
            <ItemTemplate>
                <table class="style1" frame="box" 
                    style="border-color: #000000; background-color: rgba(255,255,255,0.5);">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("PerformanceId") %>' 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server"
                                ImageUrl='<%# Bind("PerformancePhoto") %>' style="text-align: center" 
                                Height="130px" Width="174px"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PerformanceName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Date:"></asp:Label>
                            &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Bind("PerformanceDate") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton8" runat="server" CommandArgument="Show" 
                                CommandName="Show" ImageUrl="/Photos/ShowIcon.png" Height="20px" 
                                Width="20px"/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    <asp:Label ID="Label14" runat="server" style="font-weight: 700" Font-Size="X-Large">Dances you might like:</asp:Label>
    &nbsp;<asp:Label ID="Label15" runat="server"></asp:Label>
    <asp:DataList ID="DataList2" runat="server" CellPadding="5" CellSpacing="5" class="lists" 
        RepeatDirection="Horizontal" onitemcommand="DataList2_ItemCommand" 
        onitemdatabound="DataList2_ItemDataBound" RepeatColumns="5">
        <ItemStyle BorderColor="White" Width="250px" />
        <ItemTemplate>
            <table class="style2" frame="box" 
                style="border-color: #000000; background-color: rgba(255,255,255,0.5);">
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("DanceId") %>' 
                            Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image2" runat="server" Height="130px" 
                            ImageUrl='<%# Bind("DancePhoto") %>' Width="172px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("DanceName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" style="font-weight: 700" 
                            Text="Dance style:"></asp:Label>
                        &nbsp;<asp:Label ID="Label13" runat="server" Text='<%# Bind("DanStyleCatId") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton" runat="server" 
                            ImageUrl="/Photos/ShowIcon.png" CommandArgument="ShowDance" 
                            CommandName="ShowDance" Height="20px" Width="20px"  />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    &nbsp;<asp:Label ID="Label16" runat="server" style="font-weight: 700" 
            Text="General upcoming performances:" Font-Size="X-Large"></asp:Label>
        &nbsp;<asp:Label ID="Label17" runat="server" Text=""></asp:Label>
        <asp:DataList ID="DataList3" runat="server" CellSpacing="5" class="lists" 
            onitemcommand="DataList1_ItemCommand" RepeatColumns="5" 
            RepeatDirection="Horizontal" onitemdatabound="DataList3_ItemDataBound" 
            CellPadding="5">
            <ItemStyle Width="250px" />
            <ItemTemplate>
                <table class="style1" frame="box" 
                    style="border-color: #000000; background-color: rgba(255,255,255,0.5);" 
                    width="900px">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("PerformanceId") %>' 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" Height="142px" 
                                ImageUrl='<%# Bind("PerformancePhoto") %>' style="text-align: center" 
                                Width="174px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("PerformanceName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Date:"></asp:Label>
                            &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Bind("PerformanceDate") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton10" runat="server" CommandArgument="Show" 
                                CommandName="Show" ImageUrl="/Photos/ShowIcon.png" Height="20px" 
                                Width="20px"/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    &nbsp;<br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" />
        <br />
&nbsp;<asp:Label ID="Label8" runat="server" BackColor="Red" ForeColor="White" 
            Width="20px"></asp:Label>
    </div>
    </form>
</body>
</html>
