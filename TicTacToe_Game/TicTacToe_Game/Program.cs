using System;

char[] board = new char[9];
for (int i = 0; i < 9; i++)
{
    board[i] = '.';
}

char Player = 'X';  // X부터 시작
int count = 0;

while (true)
{
    ShowBoard(board);
    Console.WriteLine($"플레이어 {Player} 차례입니다.");
    Console.Write("위치를 선택하세요(1~9): ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int choice) || choice < 1 || choice > 9)
    {
        Console.WriteLine("1부터 9까지의 번호를 입력하세요.");
        continue;
    }

    int index = choice - 1;

    if (board[index] != '.')
    {
        Console.WriteLine("이미 선택한 칸입니다. 빈칸을 선택하세요");
        Console.ReadLine();
        continue;
    }

    board[index] = Player;
    count++;

    bool Win = false;

    if (board[0] != '.' && board[0] == board[1] && board[1] == board[2] ||
        board[3] != '.' && board[3] == board[4] && board[4] == board[5] ||
        board[6] != '.' && board[6] == board[7] && board[7] == board[8])
    {
        Win = true;
    }

    if (board[0] != '.' && board[0] == board[3] && board[3] == board[6] ||
        board[1] != '.' && board[1] == board[4] && board[4] == board[7] ||
        board[2] != '.' && board[2] == board[5] && board[5] == board[8])
    {
        Win = true;
    }

    if (board[0] != '.' && board[0] == board[4] && board[4] == board[8] ||
        board[2] != '.' && board[2] == board[4] && board[4] == board[6])
    {
        Win = true;
    }

    if (Win)
    {
        ShowBoard(board);
        Console.WriteLine($"플레이어 {Player} 승리!");
        break;
    }

    if (count == 9)
    {
        ShowBoard(board);
        Console.WriteLine("무승부입니다!");
        break;
    }

    Player = Player == 'X' ? 'O' : 'X';
}

static void ShowBoard(char[] board)
{
    Console.Clear();
    Console.WriteLine("=== 틱택토 게임 · 1단계 ===");
    Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다. X가 먼저 시작합니다.");
    Console.WriteLine();
    Console.WriteLine("위치 번호: ");
    Console.WriteLine(" 1 | 2 | 3 ");
    Console.WriteLine("---------");
    Console.WriteLine(" 4 | 5 | 6 ");
    Console.WriteLine("---------");
    Console.WriteLine(" 7 | 8 | 9 ");
    Console.WriteLine("");
    Console.WriteLine("현재 보드:");
    Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
    Console.WriteLine("---------");
    Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
    Console.WriteLine("");
}