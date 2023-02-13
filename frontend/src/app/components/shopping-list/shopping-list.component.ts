import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css'],
})
export class ShoppingListComponent {
  form = new FormGroup({
    item: new FormControl<string>('', { nonNullable: true }),
  });

  items: ShoppingItem[] = [
    { description: 'Beer', purchased: false },
    { description: 'Buns', purchased: false },
    { description: 'Eggs', purchased: true },
  ];

  markPurchased(item: ShoppingItem) {
    item.purchased = true;
  }

  addItem() {
    console.log(this.form.value);
    const description = this.form.controls.item.value;
    const newItem: ShoppingItem = {
      description: description,
      purchased: false,
    };
    this.items = [...this.items, newItem];
  }

  clearPurchased() {
    this.items = this.items.filter((item) => item.purchased === false);
  }

  get hasPurchasedItems() {
    return this.items.filter((item) => item.purchased).length > 0;
  }
}

type ShoppingItem = {
  description: string;
  purchased: boolean;
};
