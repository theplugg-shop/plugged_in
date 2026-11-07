import { ArrowLeft, Minus, Plus } from 'lucide-react'
import { useNavigate } from 'react-router-dom'
import { Button } from '@/components/Button'
import { Card } from '@/components/Card'
import { useCart } from '@/context/CartContext'

export default function CartPage() {
  const navigate = useNavigate()
  const { lines, setQuantity, removeLine, clear, subtotal } = useCart()

  const placeOrder = () => {
    const orderId = Math.random().toString(36).slice(2, 8)
    clear()
    navigate(`/tracking/${orderId}`)
  }

  return (
    <div className="mx-auto max-w-3xl px-4 pt-5 sm:px-6 md:pt-8">
      <div className="flex items-center gap-3">
        <button onClick={() => navigate(-1)} aria-label="Back" className="md:hidden">
          <ArrowLeft size={20} />
        </button>
        <div className="text-lg font-extrabold md:text-2xl">Cart & Checkout</div>
      </div>

      {lines.length === 0 ? (
        <p className="mt-10 text-center text-sm text-muted">Your bag is empty.</p>
      ) : (
        <>
          <div className="mt-5 space-y-3">
            {lines.map((line) => (
              <Card key={`${line.productId}-${line.size}`} className="flex gap-3 p-3">
                <div className="h-16 w-16 shrink-0 overflow-hidden rounded-xl bg-surface-2">
                  {line.image && (
                    <img src={line.image} alt={line.title} className="h-full w-full object-cover" />
                  )}
                </div>
                <div className="flex-1">
                  <div className="text-xs font-bold leading-tight">{line.title}</div>
                  <div className="mt-0.5 text-[10.5px] font-semibold text-muted">
                    Ink · {line.size}
                  </div>
                  <div className="mt-2 flex items-center gap-2">
                    <button
                      onClick={() =>
                        line.quantity <= 1
                          ? removeLine(line.productId, line.size)
                          : setQuantity(line.productId, line.size, line.quantity - 1)
                      }
                      className="flex h-6 w-6 items-center justify-center rounded-full bg-surface-2"
                    >
                      <Minus size={12} />
                    </button>
                    <span className="w-4 text-center text-xs font-bold">{line.quantity}</span>
                    <button
                      onClick={() => setQuantity(line.productId, line.size, line.quantity + 1)}
                      className="flex h-6 w-6 items-center justify-center rounded-full bg-surface-2"
                    >
                      <Plus size={12} />
                    </button>
                  </div>
                </div>
                <div className="text-xs font-extrabold">
                  R{(line.unitPrice * line.quantity).toFixed(2)}
                </div>
              </Card>
            ))}
          </div>

          <div className="mt-8 h-12 md:hidden" />

          <div className="fixed inset-x-0 bottom-0 border-t border-line bg-surface p-4 md:static md:mt-6 md:border-0 md:bg-transparent md:p-0">
            <Button variant="volt" className="w-full md:w-auto md:px-8" onClick={placeOrder}>
              Place Order · R{subtotal.toFixed(2)}
            </Button>
          </div>
        </>
      )}
    </div>
  )
}
