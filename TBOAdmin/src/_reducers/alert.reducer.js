import {alertConstants} from "../_constants";

export function alert(state = {}, action) {
  switch (action.type) {
    case alertConstants.SUCCESS:
      return {
        type: 'success',
        message: alert.message
      };
    case alertConstants.ERROR:
      return {
        type: 'danger',
        message: alert.message
      };
    case alertConstants.INFO:
      return {
        type: 'info',
        message: alert.message
      };
    case alertConstants.CLEAR:
      return {};
    default:
      return state;
  }
}
