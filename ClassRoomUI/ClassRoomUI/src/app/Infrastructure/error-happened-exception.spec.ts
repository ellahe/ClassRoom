import { ErrorHappenedException } from './error-happened-exception';

describe('ErrorHappenedException', () => {
  it('should create an instance', () => {
    expect(new ErrorHappenedException()).toBeTruthy();
  });
});
