using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wowiebot
{
    public partial class CommandsHelpForm : Form
    {
        public CommandsHelpForm()
        {
            InitializeComponent();
            helpText.Text = @"This is the list of bot commands. When a user enters a command in the chat, the bot will respond with the message in the table.
Commands are case insensitive and can contain alphanumeric characters and underscores.
You can enter multiple commands in the Command field separated by commas. Each of the commands will be used to trigger the 
message and the first will appear in the $COMMANDS list, if Show in commands list is enabled.

You can use variables in the message that the bot will replace with other data. You can use any of:

$QUOTE: A random quote from the list of quotes, or if the list is empty, a placeholder string
$QNUM: The index of the quote selected
$BROADCASTER: The username of the broadcaster
$SENDER: The username of the user who sent the command
$GAME: The game the broadcaster is currently playing
$TITLE: The current title of the broadcaster's stream
$UPHOURS: Whole number of hours the broadcaster has been live
$UPMINUTES: Whole number of minutes the broadcaster has been live
$8BALL: A random choice from the 8-Ball Choices
$CALCULATOR: Evaluates a mathematical expression
$COMMANDS: A list of all commands with ""Show in commands list"" checked

These variables don't get replaced by things, but change the command to do something else.

$ADDQUOTE: Makes the command add a quote
$VOTEYES: Makes the command the ""agree"" command for adding quotes (only has an effect when using voting for quote adding)";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
