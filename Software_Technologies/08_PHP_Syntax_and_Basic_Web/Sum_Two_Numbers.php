<?php
    if (isset($_GET['num1']) && isset($_GET['num2'])){
        $num1 = intval($_GET['num1']);
        $num2 = intval($_GET['num2']);
        $result = $num1 + $num2;
        echo ("$num1 + $num2 = $result");
    }
?>
<form>
    <div>First Number:</div>
    <input type="number" name="num1" />
    <div>Second Number:</div>
    <input type="number" name="num2" />
    <div><input type="submit" /></div>
</form>

