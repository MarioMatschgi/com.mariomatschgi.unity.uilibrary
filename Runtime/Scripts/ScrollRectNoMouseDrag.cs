using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MM.Libraries.UI
{
    public class ScrollRectNoMouseDrag : ScrollRect
    {
        public override void OnBeginDrag(PointerEventData eventData) { }
        public override void OnDrag(PointerEventData eventData) { }
        public override void OnEndDrag(PointerEventData eventData) { }
    }
}