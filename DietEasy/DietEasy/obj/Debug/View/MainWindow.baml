   M S B A M L   `   `   `  ����C  ?DietEasy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DietEasyDietEasy  5   	       DietEasy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DietEasy     5   	   -   5          � Title$  
MainWindow��5   	   $��855.389��6   $��1773.556��6-   .��5	      � .+�5
   
   �� -   5         ��Name$ tabMain��5
      $
��Left=�6&   $	��800��6A   $��	10,10,0,0q�6N   $	��Top=�6a   $
��1746��6y   .@�5      �� -   5         ��Name$ tabDailyFoodTitle��5      $��
Daily food��61   .��5      � -   5         �Name$ tabDailyFood��5      ���	#FFE5E5E5$��0,2,0,-2q�6D    � ColumnDefinitions 5      �� 5      $	��26* �6+   �� 5      $��3* �6+   �� 5      $	��10* �6+   �� 5      $
��357* �6+   .+�5      �� -   5         ��Name$ lblToday��5      $��Today's meals��6.   $
��Left=�6F   $��	21,26,0,0q�6a   $	��Top=�6t   $��3��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ grdTodaysMeals��5      $
��Left=�67   $��	21,57,0,0q�6R   $	��Top=�6e   $	��310��6}   $	��760��6�   $��4��6�   6�   �� 5      -   5        $ 	lblSearch��5      $��Search food��6/   $
��Left=�6E   $��	627,5,0,0q�6`   $	��Top=�6s   $	��153��6�   $��3��6�   �� 5      -   5         ��Name$ 	txtSearch��5      $
��Left=�61   $��23��6L   $��
627,31,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��439��6�   $��3��6�     5      -	   5        $ grdFoodDatabaseReference��5      $
��Left=�6A   $��
627,59,0,0q�6\   $	��Top=�6p   $	��557��6�   $	��761��6�   $��3��6�   �� 5      -
   5        $ txtServingSizeToAdd��5      $��3��6;   $
��Left=�6K   $��23��6f   $��704,618,0,0q�6r   $
 Wrap=�6�   $	��Top=�6�   $��59��6�   $��1��6�   6�   �� 5      -   5        $ lblDailyServingSize��5      $��Serving size��69   $��3��6P   $
��Left=�6`   $��627,615,0,0q�6{   $	��Top=�6�   �� 5      -   5        	 ��Name$	 btnEat��5      $��Eat the food!��6-   $��3��6E   $
��Left=�6U   $��779,618,0,0q�6p   $	��Top=�6�   $	��609��6�   6�   �� 5      -   5        $ txtCaloriesToAdd��5      $
��Left=�68   $��23��6S   $��736.003,668,0,0q�6_   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5      -   5        $ lblCalories_Copy��5      $��Calories��66   $
��Left=�6I   $��679.003,665,0,0q�6d   $	��Top=�6}   $��3��6�   �� 5      -   5        $ lblCarbs_Copy��5      $��Carbs��63   $
��Left=�6C   $��681.003,693,0,0q�6^   $	��Top=�6w   $��3��6�   �� 5      -   5        $ lblSugar_Copy��5      $��Of wich sugar��63   $
��Left=�6K   $��858.003,691,0,0q�6f   $	��Top=�6   $��3��6�   �� 5      -   5        $ lblProteins_Copy��5      $��Proteins��66   $
��Left=�6I   $��858.003,721,0,0q�6d   $	��Top=�6}   $��3��6�   �� 5       -   5        $ lblFats_Copy��5       $
��Fats��62   $
��Left=�6A   $��681.003,721,0,0q�6\   $	��Top=�6u   $��3��6�   �� 5!      -   5        $ txtCarbsToAdd��5!      $
��Left=�65   $��23��6P   $��736.003,696,0,0q�6\   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5"      -   5        $ txtSugarToAdd��5"      $
��Left=�65   $��23��6P   $��946.003,691,0,0q�6\   $
 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5#      -   5        $ txtFatsToAdd��5#      $
��Left=�64   $��23��6O   $��736.003,724,0,0q�6[   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5$      -   5        $ txtProteinsToAdd��5$      $
��Left=�68   $��23��6S   $��946.003,719,0,0q�6_   $
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5%      -   5        $ txtCaloriesTotal��5%      $
��Left=�68   $��23��6S   $��	2,551,0,0q�6_   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 5&      -   5        $ lblCalories_Copy1��5&      $��Calories��67   $��
59,548,3,0q�6J   $	��Top=�6^   �� 5'      -   5        $ lblCarbs_Copy1��5'      $��Carbs grams��64   $
��Left=�6J   $��
26,462,0,0q�6e   $	��Top=�6y   �� 5(      -   5        $ lblSugar_Copy1��5(      $��Of wich sugar��64   $
��Left=�6L   $��
86,460,0,0q�6g   $	��Top=�6{   $��3��6�   �� 5)      -   5        $ lblProteins_Copy1��5)      $��Proteins grams��67   $
��Left=�6P   $��
86,490,0,0q�6k   $	��Top=�6   $��3��6�   �� 5*      -   5        $ lblFats_Copy1��5*      $��
Fats grams��63   $
��Left=�6H   $��
26,490,0,0q�6c   $	��Top=�6w   �� 5+      -   5        $ txtCarbsTotal��5+      $
��Left=�65   $��23��6P   $��	3,465,0,0q�6\   $
 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 5,      -   5        $ txtSugarTotal��5,      $
��Left=�65   $��23��6P   $��174,460,0,0q�6\   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5-      -   5        $ txtFatsTotal��5-      $
��Left=�64   $��23��6O   $��	3,493,0,0q�6[   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 5.      -    5        $ txtProteinsTotal��5.      $
��Left=�68   $��23��6S   $��174,488,0,0q�6_   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 5/      -!   5        $	 btnDeleteDailyFood��5/      $��4��69   $��Delete selected food��6M   $
��Left=�6l   $��
21,372,0,0q�6�   $	��Top=�6�   $	��758��6�   6�   �� 50      -"   5        $ lblCarbs_Copy2��50      $��Carbs calories��64   $
��Left=�6M   $��
26,578,0,0q�6h   $	��Top=�6|   �� 51      -#   5        $ lblProteins_Copy2��51      $��Proteins calories��67   $
��Left=�6S   $��
86,606,0,0q�6n   $	��Top=�6�   $��3��6�   �� 52      -$   5        $ lblFats_Copy2��52      $��Fats calories��63   $
��Left=�6K   $��
26,606,0,0q�6f   $	��Top=�6z   �� 53      -%   5        $ txtCarbsCalories��53      $
��Left=�68   $��23��6S   $��	3,581,0,0q�6_   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 54      -&   5        $ txtFatsCalories��54      $
��Left=�67   $��23��6R   $��	3,609,0,0q�6^   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 55      -'   5        $ txtProteinsCalories��55      $
��Left=�6;   $��23��6V   $��181,604,0,0q�6b   $
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   �� 56      -(   5        $ lblCarbs_Copy3��56      $��Carbs %��64   $
��Left=�6F   $��
26,665,0,0q�6a   $	��Top=�6u   �� 57      -)   5        $ lblProteins_Copy3��57      $��
Proteins %��67   $
��Left=�6L   $��
19,726,0,0q�6g   $	��Top=�6{   �� 58      -*   5        $ lblFats_Copy3��58      $��Fats %��63   $
��Left=�6D   $��
26,693,0,0q�6_   $	��Top=�6s   �� 59      -+   5        $ txtCarbsPercentage��59      $
��Left=�6:   $��23��6U   $��	0,668,0,0q�6a   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 5:      -,   5        $ txtFatsPercentage��5:      $
��Left=�69   $��23��6T   $��	0,696,0,0q�6`   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��104��6�   $��3��6�   $��1��6�   �� 5;      --   5        $ txtProteinsPercentage��5;      $
��Left=�6=   $��23��6X   $��	0,724,0,0q�6d   $
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   $��3��6�   5<      5=      �� 5>      -.   5        $ tabDatabaseTitle��5>      $��Food database��60   .��5?      � -/   5        $ tabDatabase��5?      ���	#FFE5E5E5 5@      �� 5A      $��5* �6+   �� 5B      $
��292* �6+   .+�5D        -0   5        $ grdFoodDatabase��5D      $
��Left=�68   $��1.635,87,0,0q�6S   $	��Top=�6i   $	��518��6�   $
��1145��6�   $��1��6�   �� 5E      -1   5        $ lblSearchDatabase��5E      $��Search food��67   $
��Left=�6M   $��1.635,22,0,0q�6h   $	��Top=�6~   $	��153��6�   $��1��6�   �� 5F      -2   5        $ txtSearchDatabase��5F      $
��Left=�69   $��23��6T   $��1.635,48,0,0q�6`   $
 Wrap=�6v   $�� ��6�   $	��Top=�6�   $	��439��6�   $��1��6�   �� 5G      -3   5        $ txtFoodName��5G      $
��Left=�63   $��23��6N   $��58.635,619,0,0q�6Z   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��314��6�   $��1��6�   �� 5H      -4   5        $ lblFoodName��5H      $
��Name��61   $
��Left=�6@   $��1.635,616,0,0q�6[   $	��Top=�6r   $��1��6�   �� 5I      -5   5        $ txtCalories��5I      $
��Left=�63   $��23��6N   $��58.635,650,0,0q�6Z   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   �� 5J      -6   5        $ lblCalories��5J      $��Calories��61   $
��Left=�6D   $��1.635,647,0,0q�6_   $	��Top=�6v   $��1��6�   �� 5K      -7   5        $ lblCarbs��5K      $��Carbs��6.   $
��Left=�6>   $��3.635,675,0,0q�6Y   $	��Top=�6p   $��1��6�   �� 5L      -8   5        $ lblSugar��5L      $��Of wich sugar��6.   $
��Left=�6F   $��180.635,673,0,0q�6a   $	��Top=�6z   $��1��6�   �� 5M      -9   5        $ lblProteins��5M      $��Proteins��61   $
��Left=�6D   $��180.635,703,0,0q�6_   $	��Top=�6x   $��1��6�   �� 5N      -:   5        $ lblFats��5N      $
��Fats��6-   $
��Left=�6<   $��3.635,703,0,0q�6W   $	��Top=�6n   $��1��6�   �� 5O      -;   5        $ txtCarbs��5O      $
��Left=�60   $��23��6K   $��58.635,678,0,0q�6W   $
 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   �� 5P      -<   5        $ txtSugar��5P      $
��Left=�60   $��23��6K   $��268.635,673,0,0q�6W   $
 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   �� 5Q      -=   5        $ txtFats��5Q      $
��Left=�6/   $��23��6J   $��58.635,706,0,0q�6V   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   �� 5R      ->   5        $ txtProteins��5R      $
��Left=�63   $��23��6N   $��268.635,701,0,0q�6Z   $
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��104��6�   $��1��6�   �� 5S      -?   5        $ lblServingSizeGrams��5S      $��Serving size grams��69   $
��Left=�6V   $��440.635,619,0,0q�6q   $	��Top=�6�   $��1��6�   �� 5T      -@   5        $ txtServingSizeGrams��5T      $
��Left=�6;   $��23��6V   $��553.635,619,0,0q�6b   $
 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��197��6�   $��1��6�   �� 5U      -A   5        $	 
btnAddFood��5U      $��Add food��61   $
��Left=�6D   $��875.635,610,0,0q�6_   $	��Top=�6x   $	��271��6�   $��32��6�   $��1��6�   �� 5V      -B   5        $ lblServingSizeDescription��5V      $��Description��6?   $
��Left=�6U   $��478.635,647,0,0q�6p   $	��Top=�6�   $��1��6�   �� 5W      -C   5        $ txtServingSizeDescription��5W      $
��Left=�6A   $��23��6\   $��553.635,647,0,0q�6h   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��197��6�   $��1��6�   �� 5X      -D   5        $	 btnUpdateFood��5X      $��Update food��64   $
��Left=�6J   $��875.635,644,0,0q�6e   $	��Top=�6~   $	��271��6�   $��32��6�   $��1��6�   �� 5Y      -E   5        $	 btnClear��5Y      $��Clear��6/   $
��Left=�6?   $��875.635,680,0,0q�6Z   $	��Top=�6s   $	��271��6�   $��32��6�   $��1��6�   �� 5Z      -F   5        $	 btnDeleteFood��5Z      $��Delete food��64   $
��Left=�6J   $��875.635,716,0,0q�6e   $	��Top=�6~   $	��271��6�   $��32��6�   $��1��6�   5[      5\      �� 5]      -G   5        $ tabGoalsTitle��5]      $��
Your goals��6-   $
��Left=�6A   $��20��6\   $	��Top=�6h   $	��117��6�   $��-2,-2,-61,0q�6�   .��5^      � -H   5        $ tabGoals��5^      ���	#FFE5E5E56)   5_      5`      5b      5c      