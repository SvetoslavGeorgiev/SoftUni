yard_sq_meters = float(input())

money_for_all_land = yard_sq_meters * 7.61

discount = 0.18 * money_for_all_land

final_price = money_for_all_land - discount

print(f"The final price is: {format(final_price, '.2f')} lv.")
print(f"The discount is: {format(discount, '.2f')} lv.")
