<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDance.aspx.cs" Inherits="DanceProject.Pages.ShowDance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
background-color:#fae4e0;
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
        }
        
        
        .style1
        {
            width: 100%;
            text-align: center;
            font-family: Tahoma;
        }
        .style2
        {
            height: 42px;
        }

        
.grids
{
    background-color:rgba(255,255,255,0.5);
    position:absolute;
    left:145px;
    width:700px;
        border-style:none;
            text-align: center;
        }
#I1
        {
            width: 990px;
            height:450px;
        }


        .style3
        {
            text-align: center;
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

#ImageButton4
{
    position:absolute;
    top:550px;
    left:67px;
}

#DataList1
{
    position:absolute;
    left:345px;
            right: 447px;
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
        
        
        #Image2
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
        
        #Button6
{
    left:300px;
    background-color:#e6e6e6;

}

#Button7
{
    left:450px;
            right: 518px;
        }
#Button8
{
    left:601px;
            right: 367px;
        }
#Button9
{
    left:900px;

}
#Button10
{
    left:752px;

}


 .btn2 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:130px;
  border-radius: 4px;
  position:absolute;
  top:98px;
}

.btn2:hover {
  background-color: #555555;
  color: white;
}  

                #ImageButton7
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            right: 288px;
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
<body style="font-family: Tahoma; text-align: center;">
    <form id="form1" runat="server">
    <div style="text-align: center">
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
        <asp:Label ID="Label4" runat="server" Font-Size="XX-Large"></asp:Label>
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" /> 
                <asp:Image ID="Image2" runat="server" ImageUrl="" 
                    style="text-align: right; height: 136px; width: 240px;" />
           
<asp:Button ID="Button6" runat="server" Text="General information" class="btn2"
            onclick="Button6_Click"/>
        <asp:Button ID="Button7" runat="server" Text="Dancers" class="btn2" 
            onclick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Text="Performances" class="btn2" 
            onclick="Button8_Click"/>
        <asp:Button ID="Button9" runat="server" Text="Comments" class="btn2" 
            onclick="Button9_Click"/>   
            <asp:Button ID="Button10" runat="server" Text="Video" class="btn2" 
            onclick="Button10_Click"/>                
                <br />
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/Photos/PencilIcon.png"
            onclick="ImageButton4_Click" Height="50px" Width="50px" Visible="False"  />
                <br />
    <asp:ImageButton ID="ImageButton7" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton7_Click" 
        ToolTip="Log out" CausesValidation="False" />
                <asp:Panel ID="Panel1" runat="server" class="Panels">
                    <asp:Label ID="Label19" runat="server" Font-Size="X-Large" 
                        style="font-weight: 700" Text="General information:"></asp:Label>
                    <br />
                    <br />
                <asp:Label ID="Label1" runat="server" 
                    style="font-family: Arial, Helvetica, sans-serif; font-weight: 700" 
                    Text="Dance Id: "></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                    Text="Style Category: "></asp:Label>
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" style="font-weight: 700" 
                    Text="Dance Type: "></asp:Label>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label11" runat="server" style="font-weight: 700" 
                    Text="Dance Length: "></asp:Label>
                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label13" runat="server" style="font-weight: 700" 
                    Text="Dance Song: "></asp:Label>
                <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" style="font-weight: 700" 
                    Text="Choreographer: "></asp:Label>
            <asp:DataList ID="DataList1" runat="server" class="grids" 
                onitemcommand="DataList1_ItemCommand" RepeatColumns="1" Width="300px">
                <ItemStyle Width="200px" />
                <ItemTemplate>
                    <table class="style1" frame="box">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserFirstName") %>'></asp:Label>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("UserLastName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="80px" 
                                    ImageUrl='<%# Bind("ProfilePicture") %>' Width="88px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="/Photos/ShowIcon.png"
                                    CommandArgument="Bind(&quot;UserId&quot;)" CommandName="ShowChoreographer" 
                                    Height="20px" Width="20px"  />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" class="Panels" Visible="false">
            <div class="style3">
                <asp:Label ID="Label18" runat="server" Font-Size="X-Large" 
                    Text="Dancers in this dance:" style="font-weight: 700"></asp:Label>
            </div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand" 
    class="grids" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="UserFirstName" HeaderText="Dancer first name" 
                    SortExpression="UserFirstName" />
                    <asp:BoundField DataField="UserLastName" HeaderText="Dancer last name" 
                    SortExpression="UserLastName" />
                    <asp:ButtonField ButtonType="Button" CommandName="ShowDancer" HeaderText="Show" 
                    ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="40px" />
            </asp:GridView>
        </asp:Panel>
        <br />       
        <asp:Panel ID="Panel3" runat="server" class="Panels" Visible="false">
            <asp:Label ID="Label17" runat="server" style="font-weight: 700" Font-Size="X-Large" 
            Text="The performances this dance is in:"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                class="grids" onrowcommand="GridView3_RowCommand" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="PerformanceName" HeaderText="Performance name" 
                        SortExpression="PerformanceName" />
                    <asp:ImageField DataImageUrlField="PerformancePhoto" 
                        HeaderText="Performance photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="ShowPerformance" 
                        HeaderText="Show" ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="40px" />
            </asp:GridView>
        </asp:Panel>
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="/Photos/DeleteIcon.png"
            onclick="ImageButton8_Click" Height="50px" Width="50px" Visible="False"  />
        <br />
        <asp:Panel ID="Panel4" runat="server" class="Panels" Visible="false">
            <asp:Label ID="Label16" runat="server" style="font-weight: 700" Font-Size="X-Large" 
            Text="Comments:"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="tbox" runat="server" Columns="45" Height="75px" Rows="20" 
                TextMode="MultiLine" Width="787px"></asp:TextBox>
            <br />
            <asp:ImageButton ID="ImageButton5" runat="server" onclick="ImageButton5_Click" 
                ImageUrl="/Photos/SendIcon.png" Height="40px" Width="40px"/>
                
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                CellSpacing="4" class="grids" onrowcommand="GridView2_RowCommand" 
                onrowdatabound="GridView2_RowDataBound" GridLines="Horizontal">
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
                        ShowHeader="True" Text="Delete">
                    <ItemStyle Width="70px" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="BlockUser" ShowHeader="True" Text="Block User" 
                        Visible="False" />
                    <asp:BoundField DataField="UserId" HeaderText="User Id" Visible="False" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="40px" />
            </asp:GridView>
        </asp:Panel>
        <br />

        <asp:Panel ID="Panel5" runat="server" Visible="false" Class="Panels">
            <iframe id="I1" src="" runat="server" name="I1"></iframe>
    </asp:Panel>
        <br />
    </form>
</body>
</html>
