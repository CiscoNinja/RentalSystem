import { RentalSystemTemplatePage } from './app.po';

describe('RentalSystem App', function() {
  let page: RentalSystemTemplatePage;

  beforeEach(() => {
    page = new RentalSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
