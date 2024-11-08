using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BendRenderFeature : ScriptableRendererFeature
{
    class BendRenderPass : ScriptableRenderPass
    {
        public Material material;
        private RenderTargetHandle tempTexture;

        public BendRenderPass(Material material)
        {
            this.material = material;
            tempTexture.Init("_TemporaryColorTexture");
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null) return;

            CommandBuffer cmd = CommandBufferPool.Get("TinyPlanetEffect");

            // Get the camera target descriptor and remove depth buffer for efficiency
            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;

            // Use the current active render target as the source
            RenderTargetIdentifier source = renderingData.cameraData.renderer.cameraColorTarget;

            // Create a temporary render texture and apply the effect
            cmd.GetTemporaryRT(tempTexture.id, opaqueDesc, FilterMode.Bilinear);
            Blit(cmd, source, tempTexture.Identifier());
            Blit(cmd, tempTexture.Identifier(), source, material);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            if (tempTexture != RenderTargetHandle.CameraTarget)
            {
                cmd.ReleaseTemporaryRT(tempTexture.id);
            }
        }
    }

    public Material tinyPlanetMaterial;
    private BendRenderPass renderPass;

    public override void Create()
    {
        // Instantiate the render pass with the custom material
        renderPass = new BendRenderPass(tinyPlanetMaterial)
        {
            renderPassEvent = RenderPassEvent.AfterRenderingTransparents
        };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        // Enqueue the render pass to be executed
        if (tinyPlanetMaterial != null)
        {
            renderer.EnqueuePass(renderPass);
        }
    }
}
