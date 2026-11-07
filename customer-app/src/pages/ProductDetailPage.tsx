import { ArrowLeft } from 'lucide-react'
import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { Button } from '@/components/Button'
import { useCart } from '@/context/CartContext'
import { cn } from '@/lib/cn'
import { getProducts } from '@/lib/api'
import type { Product } from '@/types/product'

export default function ProductDetailPage() {
  const { productId } = useParams()
  const navigate = useNavigate()
  const { addLine } = useCart()

  const [product, setProduct] = useState<Product | null>(null)
  const [selectedSize, setSelectedSize] = useState<string | null>(null)

  useEffect(() => {
    getProducts().then((products) => {
      const match = products.find((p) => p.productId === Number(productId)) ?? null
      setProduct(match)
      setSelectedSize(match?.sizes[0]?.size ?? null)
    })
  }, [productId])

  if (!product) {
    return <p className="p-4 text-sm text-muted">Loading…</p>
  }

  const price = product.salePrice ?? product.originalPrice

  return (
    <div className="mx-auto max-w-5xl pb-28 md:pb-10">
      <div className="flex items-center gap-3 px-4 pt-5 md:hidden">
        <button onClick={() => navigate(-1)} aria-label="Back">
          <ArrowLeft size={20} />
        </button>
      </div>

      <div className="md:flex md:gap-10 md:px-6 md:pt-8 lg:px-8">
        <div className="mx-4 mt-3 aspect-square overflow-hidden rounded-card bg-surface-2 md:mx-0 md:mt-0 md:w-1/2">
          {product.images[0] && (
            <img src={product.images[0]} alt={product.title} className="h-full w-full object-cover" />
          )}
        </div>

        <div className="px-4 pt-4 md:w-1/2 md:px-0 md:pt-0">
          <div className="text-lg font-extrabold leading-tight tracking-[-0.01em] md:text-2xl">
            {product.title}
          </div>
          <div className="mt-0.5 text-sm font-semibold text-muted">
            {product.categoryName}
            {product.subcategoryName ? ` · ${product.subcategoryName}` : ''}
          </div>

          <div className="mt-3 flex items-baseline gap-2">
            <span className="text-xl font-extrabold">R{price.toFixed(2)}</span>
            {product.isOnSale && (
              <span className="text-sm font-semibold text-muted line-through">
                R{product.originalPrice.toFixed(2)}
              </span>
            )}
          </div>

          {product.sizes.length > 0 && (
            <div className="mt-5">
              <div className="text-[10px] font-extrabold uppercase tracking-[0.06em] text-muted">
                Size
              </div>
              <div className="mt-2 flex flex-wrap gap-2">
                {product.sizes.map((s) => (
                  <button
                    key={s.size}
                    disabled={s.quantity === 0}
                    onClick={() => setSelectedSize(s.size)}
                    className={cn(
                      'rounded-pill border border-line px-4 py-2 text-xs font-bold disabled:opacity-30',
                      selectedSize === s.size && 'border-ink bg-ink text-bg',
                    )}
                  >
                    {s.size}
                  </button>
                ))}
              </div>
            </div>
          )}

          {product.description && (
            <p className="mt-5 text-sm leading-relaxed text-muted">{product.description}</p>
          )}

          <Button
            variant="volt"
            className="mt-6 hidden w-full md:flex md:w-auto md:px-8"
            disabled={!selectedSize}
            onClick={() => {
              if (!selectedSize) return
              addLine(product, selectedSize)
              navigate('/cart')
            }}
          >
            Add to Bag
          </Button>
        </div>
      </div>

      <div className="fixed inset-x-0 bottom-0 border-t border-line bg-surface p-4 md:hidden">
        <Button
          variant="volt"
          className="w-full"
          disabled={!selectedSize}
          onClick={() => {
            if (!selectedSize) return
            addLine(product, selectedSize)
            navigate('/cart')
          }}
        >
          Add to Bag
        </Button>
      </div>
    </div>
  )
}
