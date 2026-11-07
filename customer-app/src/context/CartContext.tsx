import { createContext, useContext, useMemo, useState, type ReactNode } from 'react'
import type { Product } from '@/types/product'

export interface CartLine {
  productId: number
  title: string
  image: string | null
  size: string
  unitPrice: number
  quantity: number
}

interface CartContextValue {
  lines: CartLine[]
  addLine: (product: Product, size: string) => void
  removeLine: (productId: number, size: string) => void
  setQuantity: (productId: number, size: string, quantity: number) => void
  clear: () => void
  itemCount: number
  subtotal: number
}

const CartContext = createContext<CartContextValue | null>(null)

export function CartProvider({ children }: { children: ReactNode }) {
  const [lines, setLines] = useState<CartLine[]>([])

  const addLine = (product: Product, size: string) => {
    setLines((prev) => {
      const existing = prev.find((l) => l.productId === product.productId && l.size === size)
      if (existing) {
        return prev.map((l) => (l === existing ? { ...l, quantity: l.quantity + 1 } : l))
      }
      return [
        ...prev,
        {
          productId: product.productId,
          title: product.title,
          image: product.images[0] ?? null,
          size,
          unitPrice: product.salePrice ?? product.originalPrice,
          quantity: 1,
        },
      ]
    })
  }

  const removeLine = (productId: number, size: string) => {
    setLines((prev) => prev.filter((l) => !(l.productId === productId && l.size === size)))
  }

  const setQuantity = (productId: number, size: string, quantity: number) => {
    setLines((prev) =>
      prev.map((l) => (l.productId === productId && l.size === size ? { ...l, quantity } : l)),
    )
  }

  const clear = () => setLines([])

  const itemCount = useMemo(() => lines.reduce((sum, l) => sum + l.quantity, 0), [lines])
  const subtotal = useMemo(
    () => lines.reduce((sum, l) => sum + l.unitPrice * l.quantity, 0),
    [lines],
  )

  return (
    <CartContext.Provider value={{ lines, addLine, removeLine, setQuantity, clear, itemCount, subtotal }}>
      {children}
    </CartContext.Provider>
  )
}

export function useCart() {
  const ctx = useContext(CartContext)
  if (!ctx) throw new Error('useCart must be used within a CartProvider')
  return ctx
}
