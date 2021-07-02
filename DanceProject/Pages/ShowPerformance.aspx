<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPerformance.aspx.cs" Inherits="DanceProject.Pages.ShowPerformance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #myIframe
        {
            width: 1187px;
            height: 569px;
        }
        .style1
        {
            text-align: left;
        }
        .style3
        {
            text-align: center;
        }
        .Panels
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
            overflow:auto;
        }
         .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:130px;
  border-radius: 4px;
  position:absolute;
  top:98px;
}

.btn:hover {
  background-color: #555555;
  color: white;
}  
#Button5
{
    width:150px;
    background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
}
#Button5:hover {
  background-color: #555555;
  color: white;
}  
#Button6
{
    left:300px;
    background-color:#e6e6e6;

}

#Button7
{
    left:451px;
            right: 511px;
        }
#Button8
{
    left:604px;
            right: 358px;
        }
#Button9
{
    left:762px;
            right: 395px;
        }
#Button10
{
    left:920px;

}
#Button11
{
    left:1077px;

}
        #Image1
{
    position:absolute;
    top:260px;
            left: 10px;
        }

#Label4
{
    position:absolute;
    top:410px;
    width:240px;
            left: 14px;
            text-align: left;
        }

#Button1
{
  background-color: white;
  color: black;
  border: 1px solid #555555;
  border-radius: 4px;
}

#Button1:hover {
  background-color: #555555;
  color: white;
}  

#Pencil
{
    position:absolute;
    top:550px;
    left:67px;
    width:50px;
    height:50px;
            right: 975px;
        }
#DataList1
{
    position:absolute;
    left:345px;
}
#Calendar1
{
    position:absolute;
    left:295px;
        }

#GridView6
{position:absolute;
    left:145px;
    top:280px;
            right: 197px;
        }
#GridView1
{position:absolute;
    left:145px;
    
}
#GridView4
{position:absolute;
    left:145px;
            text-align: center;
        }
        
        
                #GridView3
{position:absolute;
    left:145px;
            text-align: center;
        }
        
                        #GridView5
{position:absolute;
    left:145px;
            text-align: center;
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

 
        
        body  
        {
            background-color:#fae4e0;

}
    
         #Button12 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:130px;
  border-radius: 4px;
}

 #Button12:hover {
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
            #ImageButton8
{
    position:absolute;
    top:550px;
    left:136px;
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
    <p>
    <asp:ImageButton ID="ImageButton5" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton5_Click" 
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
            onclick="ImageButton1_Click" ToolTip="Home page" 
        CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
        onclick="ImageButton3_Click" CausesValidation="False" />
        <asp:Image ID="Image1" runat="server" Height="150px" Width="240px"/>
        <asp:Button ID="Button11" runat="server" Text="Comments" class="btn" 
            onclick="Button11_Click"/>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="/Photos/DeleteIcon.png"
            onclick="ImageButton8_Click" Height="50px" Width="50px" 
        Visible="False"  />
        <asp:Label ID="Label4" runat="server" Font-Size="XX-Large"></asp:Label>
        <br />
        <asp:Button ID="Button6" runat="server" Text="General information" class="btn" 
            onclick="Button6_Click"/>
        <asp:Button ID="Button7" runat="server" Text="Dates" class="btn" 
            onclick="Button7_Click"/>
        <asp:Button ID="Button8" runat="server" Text="Dances" class="btn" 
            onclick="Button8_Click"/>
        <asp:Button ID="Button9" runat="server" Text="Dancers" class="btn" 
            onclick="Button9_Click"/>
        <asp:Button ID="Button10" runat="server" Text="Choreographers" 
            class="btn" onclick="Button10_Click"/>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" class="Panels" Visible="true">
            <div class="style3">
                <asp:Label ID="Label36" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700" Text="General information"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                    Text="Performance Id: "></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label26" runat="server" style="font-weight: 700" 
                    Text="Performance Length: "></asp:Label>
                <asp:Label ID="Label28" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label25" runat="server" style="font-weight: 700" 
                    Text="Performance choreographer:"></asp:Label>
                <br />
            </div>
            <asp:DataList ID="DataList1" runat="server" 
                onitemcommand="DataList1_ItemCommand" RepeatColumns="1" 
                style="text-align: center" Width="300px">
                <ItemStyle Width="300px" />
                <ItemTemplate>
                    <table class="style1" frame="box" width="300">
                        <tr>
                            <td style="text-align: center">
                                <asp:Image ID="Image2" runat="server" Height="114px" 
                                    ImageUrl='<%# Bind("ProfilePicture") %>' Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:Label ID="Label35" runat="server" style="font-weight: 700" 
                                    Text="Choreographer Name:" Visible="False"></asp:Label>
                                <br />
                                &nbsp;<asp:Label ID="Label34" runat="server" 
                                    Text='<%# Bind("UserFirstName") %>'></asp:Label>
                                <asp:Label ID="Label33" runat="server" Text='<%# Bind("UserLastName") %>'></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <asp:ImageButton ID="ImageButton12" runat="server" 
                                    CommandName="ShowChoreographer" ImageUrl="/Photos/ShowIcon.png" Height="20px" 
                                    Width="20px"/>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Italic="False" 
                    Font-Size="X-Large" Text="Performance Dates:"></asp:Label>
                <br />
                <br />
            </div>
            <asp:Calendar 
    ID="Calendar1" runat="server" 
            ondayrender="Calendar1_DayRender" 
            onselectionchanged="Calendar1_SelectionChanged" Width="400px" Height="200px"></asp:Calendar>
            <div class="style3">
                <br />
            </div>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                onrowdatabound="GridView6_RowDataBound" Width="700px" BorderStyle="None" 
                GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="PerformanceDate" HeaderText="Performance Date" 
                        SortExpression="PerformanceDate" />
                    <asp:BoundField DataField="PerformanceHour" HeaderText="Performance Hour" 
                        SortExpression="PerformanceHour" />
                    <asp:BoundField DataField="PerformancePlace" HeaderText="Performance Place" 
                        SortExpression="PerformancePlace" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="40px" />
            </asp:GridView>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel3" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <strong>
                <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Italic="False" 
                    Font-Size="X-Large" Text="Performance dances:"></asp:Label>
                <br />
                </strong>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="GridView1_RowCommand1" onrowdatabound="GridView1_RowDataBound" 
                    Width="700px" BorderStyle="None" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="DanceName" HeaderText="Dance name" />
                        <asp:ImageField DataImageUrlField="DancePhoto" HeaderText="Dance photo">
                            <ControlStyle Height="50px" Width="50px" />
                            <FooterStyle Height="50px" Width="50px" />
                            <HeaderStyle Height="50px" Width="50px" />
                            <ItemStyle Height="50px" Width="50px" />
                        </asp:ImageField>
                        <asp:ButtonField ButtonType="Button" CommandName="Show" HeaderText="Show" 
                            ShowHeader="True" Text="Show" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
        <br />

        <br />
        <asp:Panel ID="Panel4" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <asp:Label ID="Label23" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700; text-align: center;" 
                    Text="Dancers in this performance:"></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" GridLines="Horizontal" onrowcommand="GridView4_RowCommand" 
                    Width="700px">
                    <Columns>
                        <asp:BoundField DataField="UserFirstName" HeaderText="First name" 
                            SortExpression="UserFirstName" />
                        <asp:BoundField DataField="UserLastName" HeaderText="Last name" 
                            SortExpression="UserLastName" />
                        <asp:ImageField DataImageUrlField="ProfilePicture" HeaderText="Photo">
                            <ControlStyle Height="50px" Width="50px" />
                            <ItemStyle Height="50px" Width="50px" />
                        </asp:ImageField>
                        <asp:ButtonField ButtonType="Button" CommandName="ShowDancer" HeaderText="Show" 
                            ShowHeader="True" Text="Show" />
                    </Columns>
                    <HeaderStyle Height="50px" />
                    <RowStyle Height="40px" />
                </asp:GridView>
                <br />
            </div>
        </asp:Panel>
        <br />

        <br />
        <asp:Panel ID="Panel5" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <asp:Label ID="Label24" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700" Text="Choreographers in this performance:"></asp:Label>
                <br />
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
                    BorderStyle="None" GridLines="Horizontal" onrowcommand="GridView5_RowCommand" 
                    style="text-align: center" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="UserFirstName" HeaderText="First name" 
                            SortExpression="UserFirstName" />
                        <asp:BoundField DataField="UserLastName" HeaderText="Last name" 
                            SortExpression="UserLastName" />
                        <asp:ImageField DataImageUrlField="ProfilePicture" HeaderText="Photo">
                            <ControlStyle Height="50px" Width="50px" />
                            <ItemStyle Height="50px" Width="50px" />
                        </asp:ImageField>
                        <asp:ButtonField ButtonType="Button" CommandName="ShowChoreographer" 
                            HeaderText="Show" ShowHeader="True" Text="Show" />
                    </Columns>
                    <HeaderStyle Height="50px" />
                    <RowStyle Height="40px" />
                </asp:GridView>
                <br />
            </div>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel6" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <asp:Label ID="Label16" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700" Text="Comments:"></asp:Label>
                <br />
                <asp:TextBox ID="tbox" runat="server" Columns="45" Height="75px" Rows="20" 
                    TextMode="MultiLine" Width="787px"></asp:TextBox>
                <br />
                <asp:ImageButton ID="ImageButton10" runat="server" 
                    onclick="ImageButton10_Click" ImageUrl="/Photos/SendIcon.png" Width="40px" />
                <br />
            </div>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                CellSpacing="4" onrowcommand="GridView3_RowCommand" 
                onrowdeleting="GridView3_RowDeleting" style="text-align: center" 
                Width="700px" onrowdatabound="GridView3_RowDataBound" BorderStyle="None" 
                GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="UserFirstName" HeaderText="User first name" 
                        SortExpression="UserId">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UserLastName" HeaderText="User last name" 
                        SortExpression="UserLastName">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CommentContent" HeaderText="Comment" 
                        SortExpression="CommentContent">
                    <ItemStyle Width="600px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CommentDate" HeaderText="Date" 
                        SortExpression="CommentDate">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Button" CommandName="DeleteComment" 
                        ShowHeader="True" Text="Delete" />
                    <asp:ButtonField ButtonType="Button" CommandName="BlockUser" ShowHeader="True" Text="Block User" 
                        Visible="False" />
                    <asp:BoundField DataField="UserId" HeaderText="User Id" Visible="False" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="40px" />
            </asp:GridView>
            <div class="style3">
                <br />
            </div>
        </asp:Panel>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="Pencil" ImageUrl="/Photos/PencilIcon.png" runat="server" onclick="Button2_Click"
            Visible="False"/>
        <div class="style1">
            <br />
        <br />
        <br />
            <br />
        <br />
        </div>
    </div>
    </form>
</body>
</html>
