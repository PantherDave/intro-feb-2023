describe('Declaring Variables in TypeScript', () => {
  describe('Explicity Typed Variables', () => {
    it('defining types', () => {
      if ('defining types') {
        let myName: string | number;

        myName = 'Jeff';

        expect(myName).toEqual('Jeff');
        expect(typeof myName).toEqual('string');

        myName = 1138;
        expect(typeof myName).toEqual('number');

        // myName = (a: number, b: number) => a + b;
        // expect(typeof myName).toEqual('function');
      }
    });
  });

  describe('custom types', () => {
    it('can use types', () => {
      let beer: Product = {
        sku: 'beer',
        qty: 6,
        price: 11.99,
        description: 'Stuff to drink',
      };

      let p2: SummaryProduct = {
        price: 9.99,
        description: 'Some products',
      };
    });
    it('can us interface', () => {
      let bob: Customer = {
        name: 'Bob',
        creditLimit: 1000.0,
      };
    });
    it('can use classes', () => {
      let thisClass = new Course('Intro to Programming', 10);

      expect(thisClass.numberOfDays).toEqual(10);
      expect(thisClass.title).toEqual('Intro to Programming');
    });
  });
});

type Product = {
  sku: string;
  price: number;
  qty: number;
  description?: string;
};

type SummaryProduct = Pick<Product, 'price' | 'description'>;

type SummaryProduct2 = Omit<Product, 'sku'>;

interface Customer {
  name: string;
  creditLimit: number;
}

class Course {
  constructor(public title: string, public numberOfDays: number) {}

  getInfo() {
    return `THis course is ${this.title} and is ${this.numberOfDays} days long`;
  }
}
