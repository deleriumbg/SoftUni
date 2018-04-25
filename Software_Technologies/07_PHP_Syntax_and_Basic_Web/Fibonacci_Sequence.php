<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
        if (isset($_GET['num'])) {
            $num = $_GET['num'];
            $fib = array(1, 1, 2);
                $first = 1;
                $second = 1;
                $sum = 2;
                for ($i = 3; $i < $num; $i++) {
                    $first = $second;
                    $second = $sum;
                    $sum = $first + $second;
                    array_push($fib, $sum);
                }
                echo implode(" ", $fib);
        }
    ?>
</body>
</html>