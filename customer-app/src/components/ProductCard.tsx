import { useNavigate } from 'react-router-dom'
import type { Product } from '@/types/product'
import { Card } from './Card'

export function ProductCard({ product }: { product: Product }) {
  const navigate = useNavigate()
  const image = product.images[0]

  return (
    <Card
      role="button"
      tabIndex={0}
      onClick={() => navigate(`/product/${product.productId}`)}
      className="cursor-pointer"
    >
      <div className="aspect-[4/5] w-full overflow-hidden rounded-xl bg-surface-2">
        {image && <img src={image} alt={product.title} className="h-full w-full object-cover" />}
      </div>
      <div className="mt-2 text-xs font-bold leading-tight">{product.title}</div>
      <div className="mt-0.5 text-[10.5px] font-semibold text-muted">{product.categoryName}</div>
      <div className="mt-1.5 flex items-baseline gap-1.5">
        <span className="text-xs font-extrabold">
          R{(product.salePrice ?? product.originalPrice).toFixed(0)}
        </span>
        {product.isOnSale && (
          <span className="text-[10px] font-semibold text-muted line-through">
            R{product.originalPrice.toFixed(0)}
          </span>
        )}
      </div>
    </Card>
  )
}
