const { OrderClient } = require('./src/generated/order_grpc_web_pb');
const { CreateOrderRequest, OrderItem } = require('./src/generated/order_pb');

const client = new OrderClient('http://localhost:5100');

function placeOrder() {
  const orderId = parseInt(document.getElementById('orderId').value);
  const userId = document.getElementById('userId').value;

  const itemDivs = document.querySelectorAll('.item');
  const items = Array.from(itemDivs).map(div => {
    const item = new OrderItem();
    item.setItemId(parseInt(div.querySelector('.itemId').value));
    item.setQuantity(parseInt(div.querySelector('.itemQty').value));
    return item;
  });

  const request = new CreateOrderRequest();
  request.setId(orderId);
  request.setUserId(userId);
  request.setItemsList(items);

  client.createOrder(request, {}, (err, response) => {
    if (err) {
      window.showResult(false, `Error: ${err.message}`);
      return;
    }
    window.showResult(response.getSuccess(), JSON.stringify({
      success: response.getSuccess(),
      messages: response.getMessagesList()
    }, null, 2));
  });
}

window.placeOrder = placeOrder;