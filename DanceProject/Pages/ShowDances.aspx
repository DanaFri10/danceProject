<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDances.aspx.cs" Inherits="DanceProject.ShowDancesDL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            width: 180px;
        }
        .style2
        {
            width: 100%;
            margin-right: 0px;
        }
        .style5
        {
            width: 204px;
            text-align: left;
            background-color:rgba(255,255,255,0.5);
        }
        .style7
        {
            width: 191px;
            text-align: left;
            background-color: rgba(255,255,255,0.5);
        }
        body  {
background-color:#fae4e0;
}
.btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        width: 130px;
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

.Panels
{
    width:300px;
    height:60px;
    overflow:auto;
}
#Panel4
{
    width:1215px;
    height:245px;
    overflow:auto;
}

#Panel1
{
    position:absolute;
    left:830px;
    top:382px;
    width:400px;
    height:150px;
    overflow:auto;
}

#GridView1
{
    background-color:rgba(255,255,255,0.5);
}
   
        .style8
        {
            width: 191px;
            text-align: left;
            background-color: rgba(255,255,255,0.5);
            height: 83px;
        }
        .style9
        {
            width: 204px;
            text-align: left;
            background-color: rgba(255,255,255,0.5);
            height: 83px;
        }

        #ImageButton3
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
        
        
        #ImageButton4
        {
            position:absolute;
            top:27px;
            left:1102px;
            right: 227px;
            z-index:5;
        }
        
        #ImageButton5
        {
            position:absolute;
            top:24px;
            left:1159px;
            height: 42px;
            width: 43px;
        }
        #Button6 
        {
             position:absolute;
            top:64px;
            left:1169px;
  background-color: #555555;
  color: white;
  border: 1px solid white;
        height: 30px;
  border-radius: 4px;
}

#Button6:hover {
  background-color: white;
  color: #555555;
  border: 1px solid #555555;
}

        #Button7 
        {
             position:absolute;
            top:103px;
            left:1170px;
  background-color: #555555;
  color: white;
  border: 1px solid white;
        height: 30px;
  border-radius: 4px;
}

#Button7:hover {
  background-color: white;
  color: #555555;
  border: 1px solid #555555;
}

#ImageButton11
{
    position:absolute;
    top:555px;
    left:1000px;
            right: 81px;
        }
#ImageButton12
{
        position:absolute;
    top:555px;
    left:1060px;
}
    
       
        #ImageButton13
        {
            position:absolute;
            top:24px;
            left:1159px;
            height: 42px;
            width: 43px;
        }
            
                       #ImageButton13
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
        }
        #Button10
        {
            background-color:#e6e6e6;
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
<body style="text-align: center; font-family: Tahoma">
    <form id="form1" runat="server">
    <div style="text-align: center">
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
   <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" onmenuitemclick="Menu_MenuItemClick">
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem Text="Show dances" 
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
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton4_Click" CausesValidation="False" />

            <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" 
            onmenuitemclick="Menu_MenuItemClick" >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem Text="Show dances" 
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
            Height="70px"  Visible="false" BackColor="White" Width="1364px" onmenuitemclick="Menu_MenuItemClick" 
            >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem Text="Show dances" 
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

        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton3_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton5" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton5_Click" CausesValidation="False" />
        <br />
    <asp:ImageButton ID="ImageButton13" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton13_Click" 
        ToolTip="Log out" CausesValidation="False" />
        <br />
        <table class="style2">
            <tr>
                <td class="style8">
        <asp:Label ID="Label5" runat="server" Text="Filter by dance styles: " 
                        style="font-weight: 700"></asp:Label>
                    <asp:Panel ID="Panel2" runat="server" class="Panels">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
                <td class="style8">
                    <asp:Label ID="Label6" runat="server" Text="Filter by dance types:" 
                        style="font-weight: 700"></asp:Label>
                    <asp:Panel ID="Panel3" runat="server" class="Panels">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
                <td class="style9">
                    <asp:Label ID="Label8" runat="server" Text="Filter by dance length:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Text="" Placeholder="From" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Text="" Placeholder="To"></asp:TextBox>
                </td>
                <td class="style9">
                    <asp:Label ID="Label24" runat="server" Text="Recomended dances:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:CheckBoxList ID="CheckBoxList3" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    <asp:Label ID="Label19" runat="server" style="font-weight: 700" 
                        Text="Filter by creation date:"></asp:Label>
                    <br />
                    <asp:Label ID="Label22" runat="server" Text="From: "></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" Placeholder="From"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton1_Click" Height="10px" Width="10px"/>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="To: "></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" Placeholder="To"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/Photos/X.png" 
                        onclick="ImageButton2_Click" Height="10px" Width="10px"/>
                </td>
                <td class="style7">
                    <asp:Label ID="Label20" runat="server" style="font-weight: 700" 
                        Text="Filter by performances:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style5">
                    <asp:Label ID="Label25" runat="server" Text="Filter by dancers:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList4" runat="server" >
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style5" style="padding: 10px">
                    <asp:Label ID="Label21" runat="server" Text="Filter by choreographers:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" >
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Filter" onclick="Button3_Click" class="btn" />
        &nbsp;<asp:Button ID="Button9" runat="server" onclick="Button9_Click" 
            Text="Show all dances" class="btn"/>
        &nbsp;<asp:Button ID="Button10" runat="server" 
                        onclick="Button10_Click" Text="My dances" class="btn"/>
        &nbsp;<asp:Button ID="Button11" runat="server" onclick="Button11_Click" 
            Text="Dances you liked" class="btn"/>
        &nbsp;<asp:Button ID="Button12" runat="server" onclick="Button12_Click" 
            Text="Invalid dances" class="btn" Visible="False"/>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Search for dance name: " 
            style="font-weight: 700"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Text=""></asp:TextBox>
        <asp:ImageButton ID="ImageButton6" runat="server" onclick="ImageButton6_Click" 
            ImageUrl="/Photos/SearchIcon.png" Height="30px" Width="30px" />
&nbsp;<br />
        <br />
        <asp:Panel ID="Panel4" runat="server">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="6" 
            RepeatDirection="Horizontal" style="text-align: center" 
            BorderColor="Black" CellPadding="5" CellSpacing="5" Font-Bold="False" 
            Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" 
            Font-Strikeout="False" Font-Underline="False" 
            onitemcommand="DataList1_ItemCommand" 
            onitemdatabound="DataList1_ItemDataBound" Width="500px" >
                <ItemStyle Width="300px" BorderColor="Black" />
                <ItemTemplate>
                    <table class="style1" align="center" frame="box" bgcolor=" rgba(255,255,255,0.6);" 
                    style="border-color: #000000; background-color: rgba(255, 255, 255, 0.5);" >
                        <tr>
                            <td>
                                <asp:Image ID="Image2" runat="server" Height="142px" 
                                ImageUrl='<%# Bind("DancePhoto") %>' Width="174px" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Like" 
                                Height="23px" ImageUrl="/Photos/EmptyLike.png" Width="24px" />
                                <br />
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("DanceName") %>'></asp:Label>
                                <br />
                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("DanceId") %>' 
                                Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="/Photos/ShowIcon.png"
                                CommandName="ShowDances" CommandArgument="Bind(&quot;DanceId&quot;)" Height="20px" Width="20px"/>
                                &nbsp;<asp:ImageButton ID="ImageButton8" runat="server" CommandName="EditDance" 
                                    ImageUrl="/Photos/PencilIcon.png" Height="20px" Width="20px" 
                                    Visible="False"/>
                                &nbsp;<asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="/Photos/DeleteIcon.png"
                                CommandName="Delete" Height="20px" Width="20px" Visible="False"/>
                                <asp:ImageButton ID="ImageButton10" runat="server" CommandName="AddDance" 
                                    Height="20px" ImageUrl="/Photos/PlusIcon.png" Visible="False" Width="20px" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>

        <asp:Panel ID="Panel1" runat="server" Width="484px" Visible="false">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            ShowFooter="True" onrowcommand="GridView1_RowCommand" 
            onrowdatabound="GridView1_RowDataBound" 
            onrowdeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="DanceName" HeaderText="Dance Name" 
                    SortExpression="DanceName" />
                    <asp:ImageField DataImageUrlField="DancePhoto" HeaderText="Dance Photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <FooterStyle Height="50px" Width="50px" />
                        <HeaderStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:TemplateField FooterText="Dance length" 
                    HeaderText="Dance length">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("DanceLength") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="Label14" runat="server" Text="Performance length: "></asp:Label>
                            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="ShowDance1" HeaderText="Show" 
                    ShowHeader="True" Text="Show"/>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
                    ShowHeader="True" Text="Delete"/>
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:ImageButton ID="ImageButton11" runat="server" 
            onclick="ImageButton11_Click" ImageUrl="/Photos/TickIcon.png" Visible="False" 
            Height="50px" Width="50px"/>
                    <asp:ImageButton ID="ImageButton12" runat="server" 
            onclick="ImageButton12_Click" ImageUrl="/Photos/X.png" Visible="False" 
            Height="50px" Width="50px"/>
        <br />
        <asp:Label ID="Label12" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
