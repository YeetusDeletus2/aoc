// namespace Day2Console;
//
// using Day2Console;
//
// public class part1
// {
//     FileReader fr = new FileReader();
//     
//     List<List<int>> inputList =
//         fr.readFile("C:\\Users\\11897\\RiderProjects\\Huiswerk\\aoc\\week1-day2\\Day2Console\\input.txt");
//     
//     int answer = 0;
//     
//     foreach (List<int> list in inputList)
//     {
//         int curr = list[0];
//         int next = list[1];
//         int count = 0;
//         bool notsafe = false;
//         int increasing = 0; // 0 unused, 1 inc, 2 dec
//         foreach (int i in list)
//         {
//             count++;
//             if (increasing == 0)
//             {
//                 increasing = curr > next ? 2 : 1;
//             }
//     
//             if (curr > next & increasing == 2)
//             {
//                 // decreasing
//                 if (curr - 3 > next)
//                 {
//                     // too much, unsafe
//                     notsafe = true;
//                 }
//                 else
//                 {
//                     // safe
//                 }
//             }
//             else if (curr < next & increasing == 1)
//             {
//                 // increasing
//                 if (curr + 3 < next)
//                 {
//                     // too much, unsafe
//                     notsafe = true;
//                 }
//                 else
//                 {
//                     // safe
//                 }
//             }
//             else
//             {
//                 notsafe = true;
//             }
//     
//             try
//             {
//                 curr = next;
//                 next = list[count + 1];
//             }
//             catch (Exception e)
//             {
//                 if (!notsafe)
//                 {
//                     answer++;
//                 }
//             }
//         }
//     }
//     
     // Console.WriteLine(answer);
// }
//
